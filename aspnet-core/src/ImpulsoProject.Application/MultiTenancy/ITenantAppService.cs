using Abp.Application.Services;
using ImpulsoProject.MultiTenancy.Dto;

namespace ImpulsoProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

