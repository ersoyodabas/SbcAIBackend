using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IMenuService
    {
        Task<ReturnObject> SaveMenuAsync(MenuDto dto);
        Task<ReturnObject> GetAllMenusAsync();
        Task<ReturnObject> GetMenuByIdAsync(int id);
        Task<ReturnObject> DeleteMenuAsync(int id);
    }
}
