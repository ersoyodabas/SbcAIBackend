using System.Collections;
using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;
using Sbc.DTO.LoginPanel;

namespace Sbc.SERVICE
{
    public class UserService : GenericCrudService<user, UserDto>, IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService() : this(new UserRepository())
        {
        }

        public UserService(UserRepository repository) : base(repository)
        {
            _userRepository = repository;
        }

        public Task<ReturnObject> SaveUserAsync(UserDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllUsersAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetUserByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteUserAsync(int id)
            => DeleteAsync(id);

        public async Task<ReturnObject> GetUsersPagedAsync(
            int page, int pageSize,
            string? search, string? role, bool? active, bool? banned,
            string? sortBy, bool sortDesc)
        {
            try
            {
                var (items, total) = await _userRepository.GetPagedAsync(
                    page, pageSize, search, role, active, banned, sortBy, sortDesc);

                var dtos = items.Select(item =>
                {
                    var dto = MapEntityToDto(item.User);
                    if (dto != null)
                    {
                        dto.password = string.Empty;
                        dto.email_code = null;
                        dto.password_reset_code = null;
                        dto.auto_login_code = null;
                        dto.web_update_time = item.WebUpdateTime;
                    }
                    return dto;
                }).ToList();

                return new ReturnObject
                {
                    result = true,
                    message = "Kullanicilar getirildi.",
                    data = new { items = dtos, total, page, pageSize }
                };
            }
            catch (Exception ex)
            {
                return new ReturnObject
                {
                    result = false,
                    message = $"Hata: {ex.Message}",
                    data = null
                };
            }
        }

        public async Task<ReturnObject> GetUserByEmailAsync(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return new ReturnObject
                    {
                        result = false,
                        message = "Email gereklidir.",
                        data = null
                    };
                }

                var user = await _userRepository.GetUserByEmailAsync(email);
                
                if (user == null)
                {
                    return new ReturnObject
                    {
                        result = false,
                        message = "Kullanıcı bulunamadı.",
                        data = null
                    };
                }

                var dto = MapEntityToDto(user);
                return new ReturnObject
                {
                    result = true,
                    message = "Kullanıcı getirildi.",
                    data = dto
                };
            }
            catch (Exception ex)
            {
                return new ReturnObject
                {
                    result = false,
                    message = $"Hata: {ex.Message}",
                    data = null
                };
            }
        }

        public async Task<ReturnObject> GetUserForLoginPanelAsync(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return new ReturnObject
                    {
                        result = false,
                        message = "Email gereklidir.",
                        data = null
                    };
                }

                var (user, userStartups) = await _userRepository.GetUserForLoginPanelDtoAsync(email);
                
                if (user == null)
                {
                    return new ReturnObject
                    {
                        result = false,
                        message = "Kullanıcı bulunamadı.",
                        data = null
                    };
                }

                return new ReturnObject
                {
                    result = true,
                    message = "Kullanıcı (startup verileri ile) getirildi.",
                    data = new LoginPanelResponseDto
                    {
                        user = user,
                        userStartups = userStartups
                    }
                };
            }
            catch (Exception ex)
            {
                return new ReturnObject
                {
                    result = false,
                    message = $"Hata: {ex.Message}",
                    data = null
                };
            }
        }
    }
}
