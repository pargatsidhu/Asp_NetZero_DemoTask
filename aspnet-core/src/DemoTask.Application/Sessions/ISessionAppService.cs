using System.Threading.Tasks;
using Abp.Application.Services;
using DemoTask.Sessions.Dto;

namespace DemoTask.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
