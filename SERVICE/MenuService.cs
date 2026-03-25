using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class MenuService : GenericCrudService<menu, MenuDto>, IMenuService
    {
        public MenuService() : this(new MenuRepository())
        {
        }

        public MenuService(MenuRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveMenuAsync(MenuDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllMenusAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetMenuByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteMenuAsync(int id)
            => DeleteAsync(id);
    }
}
