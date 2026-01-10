using lib_domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositories.Interfaces
{    
    public interface IConnection
    {
        string? StringConexion { get; set; }

        DbSet<Audits>? Audits { get; set; }
        DbSet<Types>? Types { get; set; }
        DbSet<Products>? Products { get; set; }
        DbSet<Users>? Users { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}