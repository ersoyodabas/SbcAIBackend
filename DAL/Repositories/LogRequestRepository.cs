using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class LogRequestRepository : GenericRepository<log_request>
    {
        public LogRequestRepository() : base() { }

        public LogRequestRepository(_DbContext context) : base(context) { }
    }
}
