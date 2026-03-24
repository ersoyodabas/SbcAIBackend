using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class SbcRepository : GenericRepository<sbc>
    {
        public SbcRepository() : base() { }

        public SbcRepository(_DbContext context) : base(context) { }
    }
}
