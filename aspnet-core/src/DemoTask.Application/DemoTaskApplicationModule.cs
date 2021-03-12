using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DemoTask.Authorization;

namespace DemoTask
{
    [DependsOn(
        typeof(DemoTaskCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class DemoTaskApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<DemoTaskAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(DemoTaskApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );           
        }
    }
}
