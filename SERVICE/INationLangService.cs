using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface INationLangService
    {
        Task<ReturnObject> SaveNationLangAsync(NationLangDto dto);
        Task<ReturnObject> GetAllNationLangsAsync();
        Task<ReturnObject> GetNationLangByIdAsync(int id);
        Task<ReturnObject> DeleteNationLangAsync(int id);
    }
}
