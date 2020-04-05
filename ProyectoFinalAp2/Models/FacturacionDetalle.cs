using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Models
{
    public class FacturacionDetalle
    {
        [Key]
        public int IdFacturaDetalle { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }

        public FacturacionDetalle()
        {
            IdFacturaDetalle = 0;
            IdFactura = 0;
            IdProducto = 0;
            Descripcion = string.Empty;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
        }

        public FacturacionDetalle(int IdFacturaDetalle, int IdFactura, int IdProducto, string descripcion, int cantidad, decimal precio, decimal importe)
        {
            IdFacturaDetalle = IdFacturaDetalle;
            IdFactura = IdFactura;
            IdProducto = IdProducto;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}
