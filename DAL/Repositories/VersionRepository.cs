using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class VersionRepository : GenericRepository<version>
    {
        public VersionRepository() : base() { }

        public VersionRepository(_DbContext context) : base(context) { }
    }
}
