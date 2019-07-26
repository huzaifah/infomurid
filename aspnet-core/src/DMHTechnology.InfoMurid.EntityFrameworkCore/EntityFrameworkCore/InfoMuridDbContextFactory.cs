using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DMHTechnology.InfoMurid.Configuration;
using DMHTechnology.InfoMurid.Web;

namespace DMHTechnology.InfoMurid.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class InfoMuridDbContextFactory : IDesignTimeDbContextFactory<InfoMuridDbContext>
    {
        public InfoMuridDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<InfoMuridDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            InfoMuridDbContextConfigurer.Configure(builder, configuration.GetConnectionString(InfoMuridConsts.ConnectionStringName));

            return new InfoMuridDbContext(builder.Options);
        }
    }
}
