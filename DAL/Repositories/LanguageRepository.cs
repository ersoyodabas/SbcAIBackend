using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class LanguageRepository : GenericRepository<language>
    {
        public LanguageRepository() : base() { }

        public LanguageRepository(_DbContext context) : base(context) { }
    }
}
