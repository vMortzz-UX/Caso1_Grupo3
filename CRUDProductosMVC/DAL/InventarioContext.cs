
using System.Data.Entity;
using CRUDProductosMVC.Models;

namespace CRUDProductosMVC.DAL
{
    public class InventarioContext : DbContext
    {
        public InventarioContext()
            : base("name=InventarioContext")
        {
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
