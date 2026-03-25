using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class ChemistryService : GenericCrudService<chemistry, ChemistryDto>, IChemistryService
    {
        public ChemistryService() : this(new ChemistryRepository())
        {
        }

        public ChemistryService(ChemistryRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveChemistryAsync(ChemistryDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllChemistrysAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetChemistryByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteChemistryAsync(int id)
            => DeleteAsync(id);
    }
}
