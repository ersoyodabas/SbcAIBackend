using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class PlanRepository : GenericRepository<plan>
    {
        public PlanRepository() : base() { }

        public PlanRepository(_DbContext context) : base(context) { }
    }
}
