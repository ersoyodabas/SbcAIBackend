using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class StartupFeatureRepository : GenericRepository<startup_feature>
    {
        public StartupFeatureRepository() : base() { }

        public StartupFeatureRepository(_DbContext context) : base(context) { }
    }
}
