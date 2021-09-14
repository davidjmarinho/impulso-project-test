using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ImpulsoProject.Controllers
{
    public abstract class ImpulsoProjectControllerBase : AbpController
    {
        protected ImpulsoProjectControllerBase()
        {
            LocalizationSourceName = ImpulsoProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
