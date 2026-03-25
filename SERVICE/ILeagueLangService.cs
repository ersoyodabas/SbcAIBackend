using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface ILeagueLangService
    {
        Task<ReturnObject> SaveLeagueLangAsync(LeagueLangDto dto);
        Task<ReturnObject> GetAllLeagueLangsAsync();
        Task<ReturnObject> GetLeagueLangByIdAsync(int id);
        Task<ReturnObject> DeleteLeagueLangAsync(int id);
    }
}
