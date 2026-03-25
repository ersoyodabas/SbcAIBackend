using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class FormationService : GenericCrudService<formation, FormationDto>, IFormationService
    {
        public FormationService() : this(new FormationRepository())
        {
        }

        public FormationService(FormationRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveFormationAsync(FormationDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllFormationsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetFormationByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteFormationAsync(int id)
            => DeleteAsync(id);
    }
}
