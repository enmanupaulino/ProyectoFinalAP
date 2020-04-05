using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Models
{
    public class Clientes
    {  [Key]
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public DateTime Fecha { get; set; }
        public string Direccion { get; set; }
        public   string Telefono { get; set; }
        public decimal Deuda { get; set; }
        public Clientes()
        {
            IdCliente = 0;
            Nombre = string.Empty;
            Cedula = string.Empty;
            Correo = string.Empty;
            Fecha = DateTime.Now;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Deuda = 0;
        }
       
    }
}
