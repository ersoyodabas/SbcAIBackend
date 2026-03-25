using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IUserCoinSupplierService
    {
        Task<ReturnObject> SaveUserCoinSupplierAsync(UserCoinSupplierDto dto);
        Task<ReturnObject> GetAllUserCoinSuppliersAsync();
        Task<ReturnObject> GetUserCoinSupplierByIdAsync(int id);
        Task<ReturnObject> DeleteUserCoinSupplierAsync(int id);
    }
}
