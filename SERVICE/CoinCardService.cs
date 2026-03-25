using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class CoinCardService : GenericCrudService<coin_card, CoinCardDto>, ICoinCardService
    {
        private readonly CoinCardRepository _coinCardRepository;

        public CoinCardService() : this(new CoinCardRepository())
        {
        }

        public CoinCardService(CoinCardRepository repository) : base(repository)
        {
            _coinCardRepository = repository;
        }

        public Task<ReturnObject> SaveCoinCardAsync(CoinCardDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllCoinCardsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetCoinCardByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteCoinCardAsync(int id)
            => DeleteAsync(id);

        public async Task<ReturnObject> DeleteLowedRatioCardsAsync()
        {
            try
            {
                var deletedCount = await _coinCardRepository.DeleteLowedRatioCardsAsync(2);

                return new ReturnObject
                {
                    result = true,
                    message = $"{deletedCount} kayit silindi.",
                    data = deletedCount
                };
            }
            catch (Exception ex)
            {
                return new ReturnObject
                {
                    result = false,
                    message = $"Toplu silme sirasinda hata olustu: {ex.Message}",
                    data = null
                };
            }
        }
    }
}
