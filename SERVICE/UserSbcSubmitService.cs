using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class UserSbcSubmitService : GenericCrudService<user_sbc_submit, UserSbcSubmitDto>, IUserSbcSubmitService
    {
        public UserSbcSubmitService() : this(new UserSbcSubmitRepository())
        {
        }

        public UserSbcSubmitService(UserSbcSubmitRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveUserSbcSubmitAsync(UserSbcSubmitDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllUserSbcSubmitsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetUserSbcSubmitByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteUserSbcSubmitAsync(int id)
            => DeleteAsync(id);
    }
}
