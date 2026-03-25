using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class UserSbcService : GenericCrudService<user_sbc, UserSbcDto>, IUserSbcService
    {
        public UserSbcService() : this(new UserSbcRepository())
        {
        }

        public UserSbcService(UserSbcRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveUserSbcAsync(UserSbcDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllUserSbcsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetUserSbcByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteUserSbcAsync(int id)
            => DeleteAsync(id);
    }
}
