using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class ChemistryLangRepository : GenericRepository<chemistry_lang>
    {
        public ChemistryLangRepository() : base() { }

        public ChemistryLangRepository(_DbContext context) : base(context) { }
    }
}
