using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Models
{
    public class TrabajoDetalle
    {
        [Key]
        public int Id { get; set; }
        public int IdTrabajo { get; set; }
        public decimal CantidadHojas  { get; set; }
        public string Descripcion { get; set; }
        public decimal Total { get; set; }


        public TrabajoDetalle()
        {
            Id = 0;
            IdTrabajo = 0;
            CantidadHojas = 0;
            Descripcion = string.Empty;
            Total = 0;
        }
    }
}
