using System.Threading.Tasks;
using Abp.Application.Services;
using DemoTask.Authorization.Accounts.Dto;

namespace DemoTask.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
