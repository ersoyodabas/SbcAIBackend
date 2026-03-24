using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class ChemistryRepository : GenericRepository<chemistry>
    {
        public ChemistryRepository() : base() { }

        public ChemistryRepository(_DbContext context) : base(context) { }
    }
}
