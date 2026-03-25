using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class ClubService : GenericCrudService<club, ClubDto>, IClubService
    {
        public ClubService() : this(new ClubRepository())
        {
        }

        public ClubService(ClubRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveClubAsync(ClubDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllClubsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetClubByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteClubAsync(int id)
            => DeleteAsync(id);
    }
}
