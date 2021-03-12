using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using DemoTask.Authorization.Roles;
using DemoTask.Authorization.Users;
using DemoTask.MultiTenancy;

namespace DemoTask.EntityFrameworkCore
{
    public class DemoTaskDbContext : AbpZeroDbContext<Tenant, Role, User, DemoTaskDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Country.Country> Countries { get; set; }
        public virtual DbSet<State.State> States { get; set; }
        public DemoTaskDbContext(DbContextOptions<DemoTaskDbContext> options)
            : base(options)
        {
        }
    }
}
