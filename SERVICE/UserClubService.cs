using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class UserClubService : GenericCrudService<user_club, UserClubDto>, IUserClubService
    {
        public UserClubService() : this(new UserClubRepository())
        {
        }

        public UserClubService(UserClubRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveUserClubAsync(UserClubDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllUserClubsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetUserClubByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteUserClubAsync(int id)
            => DeleteAsync(id);
    }
}
