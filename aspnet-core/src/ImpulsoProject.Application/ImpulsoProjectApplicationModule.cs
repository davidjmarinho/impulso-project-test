using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ImpulsoProject.Authorization;

namespace ImpulsoProject
{
    [DependsOn(
        typeof(ImpulsoProjectCoreModule),
        typeof(AbpAutoMapperModule))]
    public class ImpulsoProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ImpulsoProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ImpulsoProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
