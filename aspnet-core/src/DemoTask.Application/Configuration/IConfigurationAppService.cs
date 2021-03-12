using System.Threading.Tasks;
using DemoTask.Configuration.Dto;

namespace DemoTask.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
