using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class FormationRepository : GenericRepository<formation>
    {
        public FormationRepository() : base() { }

        public FormationRepository(_DbContext context) : base(context) { }
    }
}
