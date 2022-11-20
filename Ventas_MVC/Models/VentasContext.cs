using Microsoft.EntityFrameworkCore;

namespace Ventas_MVC.Models
{
    public class VentasContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer("Data Source= MSI\\SQLEXPRESS; Initial Catalog=Ventas1; Integrated Security = true;  TrustServerCertificate = true") ;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
