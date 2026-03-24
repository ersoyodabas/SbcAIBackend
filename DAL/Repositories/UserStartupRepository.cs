using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class UserStartupRepository : GenericRepository<user_startup>
    {
        public UserStartupRepository() : base() { }

        public UserStartupRepository(_DbContext context) : base(context) { }
    }
}
