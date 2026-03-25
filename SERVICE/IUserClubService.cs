using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IUserClubService
    {
        Task<ReturnObject> SaveUserClubAsync(UserClubDto dto);
        Task<ReturnObject> GetAllUserClubsAsync();
        Task<ReturnObject> GetUserClubByIdAsync(int id);
        Task<ReturnObject> DeleteUserClubAsync(int id);
    }
}
