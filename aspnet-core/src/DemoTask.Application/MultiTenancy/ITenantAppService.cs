using Abp.Application.Services;
using DemoTask.MultiTenancy.Dto;

namespace DemoTask.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

