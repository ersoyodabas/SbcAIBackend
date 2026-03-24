using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class PackRepository : GenericRepository<pack>
    {
        public PackRepository() : base() { }

        public PackRepository(_DbContext context) : base(context) { }
    }
}
