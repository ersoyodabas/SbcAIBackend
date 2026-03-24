using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class FeatureRepository : GenericRepository<feature>
    {
        public FeatureRepository() : base() { }

        public FeatureRepository(_DbContext context) : base(context) { }
    }
}
