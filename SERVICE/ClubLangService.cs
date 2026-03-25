using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class ClubLangService : GenericCrudService<club_lang, ClubLangDto>, IClubLangService
    {
        public ClubLangService() : this(new ClubLangRepository())
        {
        }

        public ClubLangService(ClubLangRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveClubLangAsync(ClubLangDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllClubLangsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetClubLangByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteClubLangAsync(int id)
            => DeleteAsync(id);
    }
}
