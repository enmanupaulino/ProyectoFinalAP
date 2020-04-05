using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Models
{
    public class Entradas
    {
        [Key]
        public int IdEntrada { get; set; }
        [Required(ErrorMessage = "La fecha esta fuera de rango.")]
        public DateTime Fecha { get; set; }

        [ForeignKey("IdEntrada")]
        public List<EntradasDetalles> Detalle { get; set; }

        public Entradas()
        {
            IdEntrada = 0;
            Fecha = DateTime.Now;
            Detalle = new List<EntradasDetalles>();

        }
    }
}
