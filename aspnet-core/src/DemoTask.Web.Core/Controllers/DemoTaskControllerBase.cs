using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace DemoTask.Controllers
{
    public abstract class DemoTaskControllerBase: AbpController
    {
        protected DemoTaskControllerBase()
        {
            LocalizationSourceName = DemoTaskConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
