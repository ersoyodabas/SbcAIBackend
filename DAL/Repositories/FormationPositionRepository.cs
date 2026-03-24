using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class FormationPositionRepository : GenericRepository<formation_position>
    {
        public FormationPositionRepository() : base() { }

        public FormationPositionRepository(_DbContext context) : base(context) { }
    }
}
