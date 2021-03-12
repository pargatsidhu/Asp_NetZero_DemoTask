using System.Threading.Tasks;
using DemoTask.Models.TokenAuth;
using DemoTask.Web.Controllers;
using Shouldly;
using Xunit;

namespace DemoTask.Web.Tests.Controllers
{
    public class HomeController_Tests: DemoTaskWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}