using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using DemoTask.Configuration.Dto;

namespace DemoTask.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : DemoTaskAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
