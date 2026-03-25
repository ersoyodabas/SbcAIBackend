using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class UserLoginService : GenericCrudService<user_login, UserLoginDto>, IUserLoginService
    {
        public UserLoginService() : this(new UserLoginRepository())
        {
        }

        public UserLoginService(UserLoginRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveUserLoginAsync(UserLoginDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllUserLoginsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetUserLoginByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteUserLoginAsync(int id)
            => DeleteAsync(id);
    }
}
