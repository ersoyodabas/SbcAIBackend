using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class UserCoinSupplierRepository : GenericRepository<user_coin_supplier>
    {
        public UserCoinSupplierRepository() : base() { }

        public UserCoinSupplierRepository(_DbContext context) : base(context) { }
    }
}
