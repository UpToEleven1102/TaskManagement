using HuyenVu.TaskManagement.Core.Models;

namespace HuyenVu.TaskManagement.Core.ServiceInterface
{
    public interface IJwtService
    {
        public string GenerateJwtToken(UserInfoResponseModel user);
    }
}