using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class RarityService : GenericCrudService<rarity, RarityDto>, IRarityService
    {
        public RarityService() : this(new RarityRepository())
        {
        }

        public RarityService(RarityRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveRarityAsync(RarityDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllRaritysAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetRarityByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteRarityAsync(int id)
            => DeleteAsync(id);
    }
}
