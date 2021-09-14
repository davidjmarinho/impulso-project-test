using ImpulsoProject.Configuration.Dto;
using System.Threading.Tasks;

namespace ImpulsoProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
