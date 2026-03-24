using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class UserSbcSubmitRepository : GenericRepository<user_sbc_submit>
    {
        public UserSbcSubmitRepository() : base() { }

        public UserSbcSubmitRepository(_DbContext context) : base(context) { }
    }
}
