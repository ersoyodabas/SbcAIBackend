using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class PackCategoryRepository : GenericRepository<pack_category>
    {
        public PackCategoryRepository() : base() { }

        public PackCategoryRepository(_DbContext context) : base(context) { }
    }
}
