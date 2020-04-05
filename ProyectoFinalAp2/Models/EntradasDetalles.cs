using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Models
{
    public class EntradasDetalles
    {
        [Key]
        public int IdEntradaDetalle { get; set; }
        public int IdEntrada { get; set; }
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        [Range(minimum: 1, maximum: 9999999, ErrorMessage = "La Cantidad esta fuera del rango")]

        public int Cantidad { get; set; }

        public EntradasDetalles()
        {
            IdEntradaDetalle = 0;
            IdEntrada = 0;
            IdProducto = 0;
            Descripcion = string.Empty;
            Cantidad = 0;
        }

        public EntradasDetalles(int IdEntradaDetalle, int IdEntrada, int IdProducto, string descripcion, int cantidad)
        {
            IdEntradaDetalle = IdEntradaDetalle;
            IdEntrada = IdEntrada;
            IdProducto = IdProducto;
            Descripcion = descripcion;
            Cantidad = cantidad;
        }
    }
}
