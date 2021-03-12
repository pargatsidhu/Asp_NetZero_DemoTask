using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DemoTask.Configuration;
using DemoTask.Web;

namespace DemoTask.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class DemoTaskDbContextFactory : IDesignTimeDbContextFactory<DemoTaskDbContext>
    {
        public DemoTaskDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DemoTaskDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DemoTaskDbContextConfigurer.Configure(builder, configuration.GetConnectionString(DemoTaskConsts.ConnectionStringName));

            return new DemoTaskDbContext(builder.Options);
        }
    }
}
