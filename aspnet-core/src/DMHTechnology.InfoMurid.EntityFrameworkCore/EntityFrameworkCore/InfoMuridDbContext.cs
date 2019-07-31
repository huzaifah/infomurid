using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using DMHTechnology.InfoMurid.Authorization.Roles;
using DMHTechnology.InfoMurid.Authorization.Users;
using DMHTechnology.InfoMurid.MultiTenancy;
using DMHTechnology.InfoMurid.MaklumatAsas;

namespace DMHTechnology.InfoMurid.EntityFrameworkCore
{
    public class InfoMuridDbContext : AbpZeroDbContext<Tenant, Role, User, InfoMuridDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<TahunAkademik> AcademicYears { get; set; }
        public virtual DbSet<Kelas> Classes { get; set; }
        
        public InfoMuridDbContext(DbContextOptions<InfoMuridDbContext> options)
            : base(options)
        {
        }
    }
}
