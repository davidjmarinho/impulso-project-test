using Abp.Application.Services;
using ImpulsoProject.Sessions.Dto;
using System.Threading.Tasks;

namespace ImpulsoProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
