using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class UserSbcRepository : GenericRepository<user_sbc>
    {
        public UserSbcRepository() : base() { }

        public UserSbcRepository(_DbContext context) : base(context) { }
    }
}
