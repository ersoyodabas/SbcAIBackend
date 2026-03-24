using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class MailRepository : GenericRepository<mail>
    {
        public MailRepository() : base() { }

        public MailRepository(_DbContext context) : base(context) { }
    }
}
