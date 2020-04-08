using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Models
{
    public class Facturacion
    {
        [Key]
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        [Range(minimum: 1, maximum: 999999999999, ErrorMessage = "Debe seleccionar un Cliente.")]
        public string Cliente { get; set; }
        public int IdProducto { get; set; }
        //[Range(minimum:1,maximum:1000000,ErrorMessage ="El total debe se mayor a cero")]
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("IdFactura")]

        public List<FacturacionDetalle> Detalle { get; set; }


        public Facturacion()
        {
            IdFactura = 0;
            IdCliente = 0;
            Cliente = string.Empty;
            IdProducto = 0;
            Total = 0;
            Fecha = DateTime.Now;
            this.Detalle = new List<FacturacionDetalle>();

        }
    }
}
