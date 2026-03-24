using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class UserLoginAttemptRepository : GenericRepository<user_login_attempt>
    {
        public UserLoginAttemptRepository() : base() { }

        public UserLoginAttemptRepository(_DbContext context) : base(context) { }
    }
}
