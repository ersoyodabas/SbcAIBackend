using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class QualityLangRepository : GenericRepository<quality_lang>
    {
        public QualityLangRepository() : base() { }

        public QualityLangRepository(_DbContext context) : base(context) { }
    }
}
