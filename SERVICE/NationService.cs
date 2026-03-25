using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class NationService : GenericCrudService<nation, NationDto>, INationService
    {
        public NationService() : this(new NationRepository())
        {
        }

        public NationService(NationRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveNationAsync(NationDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllNationsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetNationByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteNationAsync(int id)
            => DeleteAsync(id);
    }
}
