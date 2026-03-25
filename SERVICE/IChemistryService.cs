using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IChemistryService
    {
        Task<ReturnObject> SaveChemistryAsync(ChemistryDto dto);
        Task<ReturnObject> GetAllChemistrysAsync();
        Task<ReturnObject> GetChemistryByIdAsync(int id);
        Task<ReturnObject> DeleteChemistryAsync(int id);
    }
}
