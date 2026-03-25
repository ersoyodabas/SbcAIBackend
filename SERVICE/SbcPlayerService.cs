using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class SbcPlayerService : GenericCrudService<sbc_player, SbcPlayerDto>, ISbcPlayerService
    {
        public SbcPlayerService() : this(new SbcPlayerRepository())
        {
        }

        public SbcPlayerService(SbcPlayerRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveSbcPlayerAsync(SbcPlayerDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllSbcPlayersAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetSbcPlayerByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteSbcPlayerAsync(int id)
            => DeleteAsync(id);
    }
}
