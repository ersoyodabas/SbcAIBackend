using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface ICountryService
    {
        Task<ReturnObject> SaveCountryAsync(CountryDto dto);
        Task<ReturnObject> GetAllCountrysAsync();
        Task<ReturnObject> GetCountryByIdAsync(int id);
        Task<ReturnObject> DeleteCountryAsync(int id);
    }
}
