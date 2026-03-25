using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class CardDefaultService : GenericCrudService<card_default, CardDefaultDto>, ICardDefaultService
    {
        public CardDefaultService() : this(new CardDefaultRepository())
        {
        }

        public CardDefaultService(CardDefaultRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveCardDefaultAsync(CardDefaultDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllCardDefaultsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetCardDefaultByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteCardDefaultAsync(int id)
            => DeleteAsync(id);
    }
}
