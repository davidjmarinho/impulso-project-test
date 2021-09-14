using ImpulsoProject.Roles;
using ImpulsoProject.Roles.Dto;
using ImpulsoProject.Tests;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ImpulsoProject.Test.Roles
{
    public class RoleAppService_Tests : ImpulsoProjectTestBase
    {
        private readonly IRoleAppService _roleAppService;

        public List<TestRelatorioBase> TestResult = new List<TestRelatorioBase>();

        public RoleAppService_Tests()
        {
            _roleAppService = Resolve<IRoleAppService>();
        }

        [Fact]
        public async Task GetRoles_Test()
        {
            var output = await _roleAppService.GetAllAsync(new PagedRoleResultRequestDto { MaxResultCount = 20, SkipCount = 0 });
            var tamanho = output.Items.Count;

            output.Items.Count.ShouldBeGreaterThan(0);

            TestResult.Add(new TestRelatorioBase
            {
                TestName = "GetRoles_Test",
                Description = "Teste De Obtenção de Roles",
                ExecutionDate = System.DateTime.Now,
                IsValidate = output.Items.Count > 0 ? true : false
            });

            await TestRelatorioBase.GenerateTestReport(TestResult, TestResult.Select(x => x.TestName).FirstOrDefault());
        }
    }
}
