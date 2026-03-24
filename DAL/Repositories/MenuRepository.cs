using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class MenuRepository : GenericRepository<menu>
    {
        public MenuRepository() : base() { }

        public MenuRepository(_DbContext context) : base(context) { }
    }
}
