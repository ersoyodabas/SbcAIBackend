using Sbc.DTO;

namespace Sbc.SERVICE
{
    /// <summary>
    /// Service contract for announcement operations via DTO mapping.
    /// </summary>
    public interface IAnnouncementService
    {
        Task<ReturnObject> SaveAnnouncementAsync(AnnouncementDto dto);
        Task<ReturnObject> GetAllAnnouncementsAsync();
        Task<ReturnObject> GetAnnouncementByIdAsync(int id);
        Task<ReturnObject> DeleteAnnouncementAsync(int id);

        Task<IEnumerable<AnnouncementDto>> GetAllAsync();
        Task<AnnouncementDto?> GetByIdAsync(int id);
        Task<AnnouncementDto> CreateAsync(AnnouncementDto dto);
        Task<AnnouncementDto?> UpdateAsync(int id, AnnouncementDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
