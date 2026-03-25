using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class RarityLangService : GenericCrudService<rarity_lang, RarityLangDto>, IRarityLangService
    {
        public RarityLangService() : this(new RarityLangRepository())
        {
        }

        public RarityLangService(RarityLangRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveRarityLangAsync(RarityLangDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllRarityLangsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetRarityLangByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteRarityLangAsync(int id)
            => DeleteAsync(id);
    }
}
