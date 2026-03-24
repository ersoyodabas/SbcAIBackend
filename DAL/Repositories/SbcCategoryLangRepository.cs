using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class SbcCategoryLangRepository : GenericRepository<sbc_category_lang>
    {
        public SbcCategoryLangRepository() : base() { }

        public SbcCategoryLangRepository(_DbContext context) : base(context) { }
    }
}
