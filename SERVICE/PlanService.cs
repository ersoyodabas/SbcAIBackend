using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class PlanService : GenericCrudService<plan, PlanDto>, IPlanService
    {
        public PlanService() : this(new PlanRepository())
        {
        }

        public PlanService(PlanRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SavePlanAsync(PlanDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllPlansAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetPlanByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeletePlanAsync(int id)
            => DeleteAsync(id);
    }
}
