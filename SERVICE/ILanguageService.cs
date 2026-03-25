using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface ILanguageService
    {
        Task<ReturnObject> SaveLanguageAsync(LanguageDto dto);
        Task<ReturnObject> GetAllLanguagesAsync();
        Task<ReturnObject> GetLanguageByIdAsync(int id);
        Task<ReturnObject> DeleteLanguageAsync(int id);
    }
}
