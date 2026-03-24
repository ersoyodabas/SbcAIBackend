using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class CountryRepository : GenericRepository<country>
    {
        public CountryRepository() : base() { }

        public CountryRepository(_DbContext context) : base(context) { }
    }
}
