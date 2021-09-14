using Abp.Zero.EntityFrameworkCore;
using ImpulsoProject.Authorization.Roles;
using ImpulsoProject.Authorization.Users;
using ImpulsoProject.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace ImpulsoProject.EntityFrameworkCore
{
    public class ImpulsoProjectDbContext : AbpZeroDbContext<Tenant, Role, User, ImpulsoProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public ImpulsoProjectDbContext(DbContextOptions<ImpulsoProjectDbContext> options)
            : base(options)
        {
        }
    }
}
