using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IPlanService
    {
        Task<ReturnObject> SavePlanAsync(PlanDto dto);
        Task<ReturnObject> GetAllPlansAsync();
        Task<ReturnObject> GetPlanByIdAsync(int id);
        Task<ReturnObject> DeletePlanAsync(int id);
    }
}
