using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ImpulsoProject.EntityFrameworkCore;
using ImpulsoProject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ImpulsoProject.Web.Tests
{
    [DependsOn(
        typeof(ImpulsoProjectWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ImpulsoProjectWebTestModule : AbpModule
    {
        public ImpulsoProjectWebTestModule(ImpulsoProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ImpulsoProjectWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ImpulsoProjectWebMvcModule).Assembly);
        }
    }
}