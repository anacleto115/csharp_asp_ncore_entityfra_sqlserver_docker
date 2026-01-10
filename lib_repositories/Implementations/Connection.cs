using lib_domain.Entities;
using lib_repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositories.Implementations
{
    public class Connection : DbContext, IConnection
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Audits>? Audits { get; set; }
        public DbSet<Products>? Products { get; set; }
        public DbSet<Types>? Types { get; set; }
        public DbSet<Users>? Users { get; set; }
    }
}