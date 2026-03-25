using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class UserCoinSupplierService : GenericCrudService<user_coin_supplier, UserCoinSupplierDto>, IUserCoinSupplierService
    {
        public UserCoinSupplierService() : this(new UserCoinSupplierRepository())
        {
        }

        public UserCoinSupplierService(UserCoinSupplierRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveUserCoinSupplierAsync(UserCoinSupplierDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllUserCoinSuppliersAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetUserCoinSupplierByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteUserCoinSupplierAsync(int id)
            => DeleteAsync(id);
    }
}
