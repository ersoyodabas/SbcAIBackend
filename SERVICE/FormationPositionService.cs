using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class FormationPositionService : GenericCrudService<formation_position, FormationPositionDto>, IFormationPositionService
    {
        public FormationPositionService() : this(new FormationPositionRepository())
        {
        }

        public FormationPositionService(FormationPositionRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveFormationPositionAsync(FormationPositionDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllFormationPositionsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetFormationPositionByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteFormationPositionAsync(int id)
            => DeleteAsync(id);
    }
}
