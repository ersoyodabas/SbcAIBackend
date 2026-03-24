using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class SbcCategoryRepository : GenericRepository<sbc_category>
    {
        public SbcCategoryRepository() : base() { }

        public SbcCategoryRepository(_DbContext context) : base(context) { }
    }
}
