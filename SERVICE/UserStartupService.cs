using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class UserStartupService : GenericCrudService<user_startup, UserStartupDto>, IUserStartupService
    {
        public UserStartupService() : this(new UserStartupRepository())
        {
        }

        public UserStartupService(UserStartupRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveUserStartupAsync(UserStartupDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllUserStartupsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetUserStartupByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteUserStartupAsync(int id)
            => DeleteAsync(id);
    }
}
