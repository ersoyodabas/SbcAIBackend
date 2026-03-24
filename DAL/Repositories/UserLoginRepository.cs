using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class UserLoginRepository : GenericRepository<user_login>
    {
        public UserLoginRepository() : base() { }

        public UserLoginRepository(_DbContext context) : base(context) { }
    }
}
