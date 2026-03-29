using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IUserService
    {
        Task<ReturnObject> SaveUserAsync(UserDto dto);
        Task<ReturnObject> GetAllUsersAsync();
        Task<ReturnObject> GetUserByIdAsync(int id);
        Task<ReturnObject> DeleteUserAsync(int id);
        Task<ReturnObject> GetUsersPagedAsync(int page, int pageSize, string? search, string? role, bool? active, bool? banned, string? sortBy, bool sortDesc);
        Task<ReturnObject> GetUserByEmailAsync(string email);
    }
}
