using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Models
{
    public class Trabajos

    {
        [Key]
        public int IdTrabajo { get; set; }
        public string Descripcion { get; set; }
        public decimal CantidadHojas { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

       [ForeignKey("IdTrabajo")]
        public virtual List<TrabajoDetalle> Detalles { get; set; }

        public Trabajos()
        {
            IdTrabajo = 0;
            Descripcion = string.Empty;
            Fecha = DateTime.Now;
            Detalles = new List<TrabajoDetalle>();
        }
    }
}
