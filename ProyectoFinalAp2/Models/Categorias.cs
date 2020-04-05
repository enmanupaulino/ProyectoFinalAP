using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Models
{
    public class Categorias
    {
        [Key]
        public int IdCategoria { get; set; }
        public string  Nombre { get; set; }
       
        public Categorias()
        {
            IdCategoria = 0;
            Nombre = String.Empty;
        
        }
    }
}
