using Abp.Dependency;
using Castle.Windsor.MsDependencyInjection;
using ImpulsoProject.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ImpulsoProject.Migrator.DependencyInjection
{
    public static class ServiceCollectionRegistrar
    {
        public static void Register(IIocManager iocManager)
        {
            var services = new ServiceCollection();

            IdentityRegistrar.Register(services);

            WindsorRegistrationHelper.CreateServiceProvider(iocManager.IocContainer, services);
        }
    }
}
