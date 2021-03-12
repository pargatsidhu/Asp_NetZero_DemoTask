using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DemoTask.EntityFrameworkCore;
using DemoTask.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace DemoTask.Web.Tests
{
    [DependsOn(
        typeof(DemoTaskWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class DemoTaskWebTestModule : AbpModule
    {
        public DemoTaskWebTestModule(DemoTaskEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DemoTaskWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(DemoTaskWebMvcModule).Assembly);
        }
    }
}