using CollectionMaster.DataAccess.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace CollectionMaster.DataAccess.EF.Context
{
    public class CollectionMasterContext : DbContext
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public CollectionMasterContext()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = builder.GetConnectionString("DefaultConnection");
        }

        public CollectionMasterContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        public CollectionMasterContext(IConfiguration configuration) :
            this(configuration.GetConnectionString("DefaultConnection"))
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString,
                providerOptions => providerOptions.CommandTimeout(60));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        //entities
        public DbSet<Album> Albums { get; set; }
    }
}
