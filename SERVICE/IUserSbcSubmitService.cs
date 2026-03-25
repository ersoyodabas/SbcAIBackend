using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IUserSbcSubmitService
    {
        Task<ReturnObject> SaveUserSbcSubmitAsync(UserSbcSubmitDto dto);
        Task<ReturnObject> GetAllUserSbcSubmitsAsync();
        Task<ReturnObject> GetUserSbcSubmitByIdAsync(int id);
        Task<ReturnObject> DeleteUserSbcSubmitAsync(int id);
    }
}
