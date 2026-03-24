using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class UserClubRepository : GenericRepository<user_club>
    {
        public UserClubRepository() : base() { }

        public UserClubRepository(_DbContext context) : base(context) { }
    }
}
