using Abp.Modules;
using Abp.Reflection.Extensions;
using ImpulsoProject.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ImpulsoProject.Web.Host.Startup
{
    [DependsOn(
       typeof(ImpulsoProjectWebCoreModule))]
    public class ImpulsoProjectWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ImpulsoProjectWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ImpulsoProjectWebHostModule).GetAssembly());
        }
    }
}
