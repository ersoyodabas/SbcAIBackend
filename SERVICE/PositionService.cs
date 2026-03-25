using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class PositionService : GenericCrudService<position, PositionDto>, IPositionService
    {
        public PositionService() : this(new PositionRepository())
        {
        }

        public PositionService(PositionRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SavePositionAsync(PositionDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllPositionsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetPositionByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeletePositionAsync(int id)
            => DeleteAsync(id);
    }
}
