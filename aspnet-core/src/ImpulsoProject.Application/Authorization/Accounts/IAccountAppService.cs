using Abp.Application.Services;
using ImpulsoProject.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace ImpulsoProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
