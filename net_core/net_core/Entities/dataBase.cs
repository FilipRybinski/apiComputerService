using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509.SigI;
using System.Data;

namespace net_core.Entities
{
    public class dataBase : DbContext
    {
        private readonly IConfiguration _configuration;
        public dataBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<messages> Messages { get; set; }
        public DbSet<orders> Orders { get; set; }
        public DbSet<registration_order> Registration_Orders { get; set; }
        public DbSet<singup> Singups { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=127.0.0.1;uid=root;pwd=root;database=Project");

        }
    }
}
