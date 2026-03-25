using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IUserLoginAttemptService
    {
        Task<ReturnObject> SaveUserLoginAttemptAsync(UserLoginAttemptDto dto);
        Task<ReturnObject> GetAllUserLoginAttemptsAsync();
        Task<ReturnObject> GetUserLoginAttemptByIdAsync(int id);
        Task<ReturnObject> DeleteUserLoginAttemptAsync(int id);
    }
}
