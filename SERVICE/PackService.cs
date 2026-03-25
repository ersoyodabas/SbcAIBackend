using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class PackService : GenericCrudService<pack, PackDto>, IPackService
    {
        public PackService() : this(new PackRepository())
        {
        }

        public PackService(PackRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SavePackAsync(PackDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllPacksAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetPackByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeletePackAsync(int id)
            => DeleteAsync(id);
    }
}
