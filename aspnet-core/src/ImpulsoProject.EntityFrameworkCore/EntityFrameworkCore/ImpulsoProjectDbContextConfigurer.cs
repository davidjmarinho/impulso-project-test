using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ImpulsoProject.EntityFrameworkCore
{
    public static class ImpulsoProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ImpulsoProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ImpulsoProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
