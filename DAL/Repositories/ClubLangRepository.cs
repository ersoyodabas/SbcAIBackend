using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class ClubLangRepository : GenericRepository<club_lang>
    {
        public ClubLangRepository() : base() { }

        public ClubLangRepository(_DbContext context) : base(context) { }
    }
}
