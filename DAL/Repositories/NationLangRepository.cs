using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class NationLangRepository : GenericRepository<nation_lang>
    {
        public NationLangRepository() : base() { }

        public NationLangRepository(_DbContext context) : base(context) { }
    }
}
