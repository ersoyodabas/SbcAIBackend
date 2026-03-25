using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class SbcService : GenericCrudService<sbc, SbcDto>, ISbcService
    {
        public SbcService() : this(new SbcRepository())
        {
        }

        public SbcService(SbcRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveSbcAsync(SbcDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllSbcsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetSbcByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteSbcAsync(int id)
            => DeleteAsync(id);
    }
}
