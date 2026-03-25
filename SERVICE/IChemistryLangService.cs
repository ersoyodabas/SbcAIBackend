using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IChemistryLangService
    {
        Task<ReturnObject> SaveChemistryLangAsync(ChemistryLangDto dto);
        Task<ReturnObject> GetAllChemistryLangsAsync();
        Task<ReturnObject> GetChemistryLangByIdAsync(int id);
        Task<ReturnObject> DeleteChemistryLangAsync(int id);
    }
}
