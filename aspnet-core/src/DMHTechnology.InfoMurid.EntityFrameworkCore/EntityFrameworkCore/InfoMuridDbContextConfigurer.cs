using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace DMHTechnology.InfoMurid.EntityFrameworkCore
{
    public static class InfoMuridDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<InfoMuridDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<InfoMuridDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
