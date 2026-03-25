using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IPackService
    {
        Task<ReturnObject> SavePackAsync(PackDto dto);
        Task<ReturnObject> GetAllPacksAsync();
        Task<ReturnObject> GetPackByIdAsync(int id);
        Task<ReturnObject> DeletePackAsync(int id);
    }
}
