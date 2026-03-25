using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IUserLoginService
    {
        Task<ReturnObject> SaveUserLoginAsync(UserLoginDto dto);
        Task<ReturnObject> GetAllUserLoginsAsync();
        Task<ReturnObject> GetUserLoginByIdAsync(int id);
        Task<ReturnObject> DeleteUserLoginAsync(int id);
    }
}
