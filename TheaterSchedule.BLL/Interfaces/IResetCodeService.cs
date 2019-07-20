using System.Threading.Tasks;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Interfaces;
using System.Net;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IResetCodeService
    {
        Task<ResetCodeDTO> GetByValueAsync(int value);
        void GenerateResetCodeAsync(string email);
        void ValidateCode(int code);
        void ResetPassword(string pass);
    }
}
