using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosHumanos.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Solicituds = new HashSet<Solicitud>();
        }
        [Key]
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; }

        public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
