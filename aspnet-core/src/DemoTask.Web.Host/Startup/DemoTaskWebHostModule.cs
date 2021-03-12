using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DemoTask.Configuration;

namespace DemoTask.Web.Host.Startup
{
    [DependsOn(
       typeof(DemoTaskWebCoreModule))]
    public class DemoTaskWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public DemoTaskWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DemoTaskWebHostModule).GetAssembly());
        }
    }
}
