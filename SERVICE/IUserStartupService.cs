using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IUserStartupService
    {
        Task<ReturnObject> SaveUserStartupAsync(UserStartupDto dto);
        Task<ReturnObject> GetAllUserStartupsAsync();
        Task<ReturnObject> GetUserStartupByIdAsync(int id);
        Task<ReturnObject> DeleteUserStartupAsync(int id);
    }
}
