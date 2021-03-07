using System.Threading.Tasks;
using HuyenVu.TaskManagement.Core.Models;

namespace HuyenVu.TaskManagement.Core.ServiceInterface
{
    public interface IDashboardService
    {
        Task<DashboardResponseModel> GetDashboardInfo();
    }
}