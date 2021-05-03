using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Models
{
    public partial class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int? CantidadDisponible { get; set; }
        public string Medidas { get; set; }
        public int? IdSuministro { get; set; }

        public virtual Suministro IdSuministroNavigation { get; set; }
    }
}
