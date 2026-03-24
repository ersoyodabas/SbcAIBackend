using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class AnnouncementRepository : GenericRepository<announcement>
    {
        public AnnouncementRepository() : base() { }

        public AnnouncementRepository(_DbContext context) : base(context) { }
    }
}
