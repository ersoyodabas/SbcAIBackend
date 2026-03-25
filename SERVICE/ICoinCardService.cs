using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface ICoinCardService
    {
        Task<ReturnObject> SaveCoinCardAsync(CoinCardDto dto);
        Task<ReturnObject> GetAllCoinCardsAsync();
        Task<ReturnObject> GetCoinCardByIdAsync(int id);
        Task<ReturnObject> DeleteCoinCardAsync(int id);
        Task<ReturnObject> DeleteLowedRatioCardsAsync();
    }
}
