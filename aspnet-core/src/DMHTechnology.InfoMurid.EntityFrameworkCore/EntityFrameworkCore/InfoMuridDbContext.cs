using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using DMHTechnology.InfoMurid.Authorization.Roles;
using DMHTechnology.InfoMurid.Authorization.Users;
using DMHTechnology.InfoMurid.MultiTenancy;

namespace DMHTechnology.InfoMurid.EntityFrameworkCore
{
    public class InfoMuridDbContext : AbpZeroDbContext<Tenant, Role, User, InfoMuridDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public InfoMuridDbContext(DbContextOptions<InfoMuridDbContext> options)
            : base(options)
        {
        }
    }
}
