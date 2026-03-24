using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class QualityRepository : GenericRepository<quality>
    {
        public QualityRepository() : base() { }

        public QualityRepository(_DbContext context) : base(context) { }
    }
}
