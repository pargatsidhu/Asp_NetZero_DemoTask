using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace DemoTask.EntityFrameworkCore
{
    public static class DemoTaskDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<DemoTaskDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<DemoTaskDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
