using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface ISbcLangService
    {
        Task<ReturnObject> SaveSbcLangAsync(SbcLangDto dto);
        Task<ReturnObject> GetAllSbcLangsAsync();
        Task<ReturnObject> GetSbcLangByIdAsync(int id);
        Task<ReturnObject> DeleteSbcLangAsync(int id);
    }
}
