using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class ClubRepository : GenericRepository<club>
    {
        public ClubRepository() : base() { }

        public ClubRepository(_DbContext context) : base(context) { }
    }
}
