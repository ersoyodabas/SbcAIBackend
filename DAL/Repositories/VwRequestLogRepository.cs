using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class VwRequestLogRepository : GenericRepository<vw_request_log>
    {
        public VwRequestLogRepository() : base() { }

        public VwRequestLogRepository(_DbContext context) : base(context) { }
    }
}
