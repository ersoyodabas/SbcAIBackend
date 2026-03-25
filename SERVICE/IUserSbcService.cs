using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IUserSbcService
    {
        Task<ReturnObject> SaveUserSbcAsync(UserSbcDto dto);
        Task<ReturnObject> GetAllUserSbcsAsync();
        Task<ReturnObject> GetUserSbcByIdAsync(int id);
        Task<ReturnObject> DeleteUserSbcAsync(int id);
    }
}
