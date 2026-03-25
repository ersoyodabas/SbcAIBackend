using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class ChemistryLangService : GenericCrudService<chemistry_lang, ChemistryLangDto>, IChemistryLangService
    {
        public ChemistryLangService() : this(new ChemistryLangRepository())
        {
        }

        public ChemistryLangService(ChemistryLangRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveChemistryLangAsync(ChemistryLangDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllChemistryLangsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetChemistryLangByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteChemistryLangAsync(int id)
            => DeleteAsync(id);
    }
}
