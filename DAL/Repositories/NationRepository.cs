using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class NationRepository : GenericRepository<nation>
    {
        public NationRepository() : base() { }

        public NationRepository(_DbContext context) : base(context) { }
    }
}
