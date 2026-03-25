using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class CountryService : GenericCrudService<country, CountryDto>, ICountryService
    {
        public CountryService() : this(new CountryRepository())
        {
        }

        public CountryService(CountryRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveCountryAsync(CountryDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllCountrysAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetCountryByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteCountryAsync(int id)
            => DeleteAsync(id);
    }
}
