using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class PlayerService : GenericCrudService<player, PlayerDto>, IPlayerService
    {
        public PlayerService() : this(new PlayerRepository())
        {
        }

        public PlayerService(PlayerRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SavePlayerAsync(PlayerDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllPlayersAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetPlayerByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeletePlayerAsync(int id)
            => DeleteAsync(id);
    }
}
