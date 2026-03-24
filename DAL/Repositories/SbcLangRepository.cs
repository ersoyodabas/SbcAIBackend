using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class SbcLangRepository : GenericRepository<sbc_lang>
    {
        public SbcLangRepository() : base() { }

        public SbcLangRepository(_DbContext context) : base(context) { }
    }
}
