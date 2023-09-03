using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using DVConsistPlanner.Models;
using DVConsistPlanner.Configs;

namespace DVConsistPlanner.Contexts
{
    public class DVCPContext : DbContext
    {
        readonly IConfiguration _configuration;

        public DbSet<Consist> Consists { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Locomotive> Locomotives { get; set; }
        public DbSet<License> Licenses { get; set; }

        public DVCPContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            DbSettings dbSettings = _configuration.GetSection("DbSettings").Get<DbSettings>();
            var conStrBuilder = new SqlConnectionStringBuilder(_configuration.GetConnectionString("DVCPContext"))
            {
                UserID = dbSettings.DVCPDbUser,
                Password = dbSettings.DVCPDbPass
            };

            options.UseSqlServer(conStrBuilder.ConnectionString);
        }
    }
}
