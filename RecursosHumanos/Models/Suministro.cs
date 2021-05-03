using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace RecursosHumanos.Models
{
    public partial class Suministro
    {
        public Suministro()
        {
            Productos = new HashSet<Producto>();
            Solicituds = new HashSet<Solicitud>();
        }
        [Key]
        public int IdSuministro { get; set; }
        public string NombreSuministro { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
