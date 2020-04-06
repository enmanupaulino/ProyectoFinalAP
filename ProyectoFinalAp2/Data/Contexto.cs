using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> usuarios {get; set;}
        public DbSet<Proveedores> proveedores {get; set;}
        public DbSet<Productos> productos {get; set;}
        public DbSet<Clientes>clientes {get; set;}
        public DbSet<Categorias>categorias {get; set;}
        public DbSet<Trabajos> trabajos { get; set; }
        public DbSet<Entradas> entradas { get; set; }
        public DbSet<Facturacion> facturacion { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:proyectofinalap2dbserver.database.windows.net,1433;Initial Catalog=ProyectoFinalAp2_db;Persist Security Info=False;
User ID=EnmanuelP;Password=Enmnauel1;MultipleActiveResultSets=False;Encrypt=True;
TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
