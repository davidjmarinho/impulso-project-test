using System.Threading.Tasks;
using ImpulsoProject.Models.TokenAuth;
using ImpulsoProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace ImpulsoProject.Web.Tests.Controllers
{
    public class HomeController_Tests: ImpulsoProjectWebTestBase
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