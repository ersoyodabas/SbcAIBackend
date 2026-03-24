using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class UserRepository : GenericRepository<user>
    {
        public UserRepository() : base() { }

        public UserRepository(_DbContext context) : base(context) { }
    }
}
