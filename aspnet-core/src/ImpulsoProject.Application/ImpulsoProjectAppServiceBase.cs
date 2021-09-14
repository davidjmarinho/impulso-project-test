using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using ImpulsoProject.Authorization.Users;
using ImpulsoProject.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace ImpulsoProject
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class ImpulsoProjectAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected ImpulsoProjectAppServiceBase()
        {
            LocalizationSourceName = ImpulsoProjectConsts.LocalizationSourceName;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
