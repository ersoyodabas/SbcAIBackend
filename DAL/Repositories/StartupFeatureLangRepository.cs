using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class StartupFeatureLangRepository : GenericRepository<startup_feature_lang>
    {
        public StartupFeatureLangRepository() : base() { }

        public StartupFeatureLangRepository(_DbContext context) : base(context) { }
    }
}
