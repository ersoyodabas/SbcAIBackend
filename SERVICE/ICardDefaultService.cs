using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface ICardDefaultService
    {
        Task<ReturnObject> SaveCardDefaultAsync(CardDefaultDto dto);
        Task<ReturnObject> GetAllCardDefaultsAsync();
        Task<ReturnObject> GetCardDefaultByIdAsync(int id);
        Task<ReturnObject> DeleteCardDefaultAsync(int id);
    }
}
