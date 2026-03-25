using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IVersionService
    {
        Task<ReturnObject> SaveVersionAsync(VersionDto dto);
        Task<ReturnObject> GetAllVersionsAsync();
        Task<ReturnObject> GetVersionByIdAsync(int id);
        Task<ReturnObject> DeleteVersionAsync(int id);
    }
}
