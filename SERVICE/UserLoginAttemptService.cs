using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class UserLoginAttemptService : GenericCrudService<user_login_attempt, UserLoginAttemptDto>, IUserLoginAttemptService
    {
        public UserLoginAttemptService() : this(new UserLoginAttemptRepository())
        {
        }

        public UserLoginAttemptService(UserLoginAttemptRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveUserLoginAttemptAsync(UserLoginAttemptDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllUserLoginAttemptsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetUserLoginAttemptByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteUserLoginAttemptAsync(int id)
            => DeleteAsync(id);
    }
}
