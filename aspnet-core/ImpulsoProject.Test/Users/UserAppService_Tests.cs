using ImpulsoProject.Test;
using ImpulsoProject.Users;
using ImpulsoProject.Users.Dto;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace ImpulsoProject.Tests.Users
{

    public class UserAppService_Tests : ImpulsoProjectTestBase
    {
        private readonly IUserAppService _userAppService;

        public List<TestRelatorioBase> TestResult = new List<TestRelatorioBase>();

        public UserAppService_Tests()
        {
            _userAppService = Resolve<IUserAppService>();
        }

        [Fact]
        public async Task GetUsers_Test()
        {
            var output = await _userAppService.GetAllAsync(new PagedUserResultRequestDto { MaxResultCount = 20, SkipCount = 0 });

            var tamanho = output.Items.Count;

            output.Items.Count.ShouldBeGreaterThan(0);

            TestResult.Add(new TestRelatorioBase
            {
                TestName = "GetUsers_Test",
                Description = "Teste De Obtenção de Usuário",
                ExecutionDate = System.DateTime.Now,
                IsValidate = output.Items.Count > 0 ? true : false
            });
                       
            await TestRelatorioBase.GenerateTestReport(TestResult, TestResult.Select(x => x.TestName).FirstOrDefault());
        }

        [Fact]
        public async Task CreateUser_Test()
        {
            var result = await _userAppService.CreateAsync(
                new CreateUserDto
                {
                    EmailAddress = "david.pereira@gmail.com",
                    IsActive = true,
                    Name = " David",
                    Surname = "Pereira",
                    Password = "123qwe",
                    UserName = "david.pereira",
                    RoleNames = new string[] { "admin" }
                }); ;

            var ok = result;
            
            await UsingDbContextAsync(async context =>
             {
                 var davidPUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == "david.pereira");
                 davidPUser.ShouldNotBeNull();
             });

            TestResult.Add(new TestRelatorioBase
            {
                TestName = "CreateUser_Test",
                Description = "Teste De Criação de Usuário",
                ExecutionDate = System.DateTime.Now,
                IsValidate = result.UserName.Contains("david.pereira") ? true : false
            }); ;

            await TestRelatorioBase.GenerateTestReport(TestResult, TestResult.Select(x => x.TestName).FirstOrDefault());
        }
    }
}
