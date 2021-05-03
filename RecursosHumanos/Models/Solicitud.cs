using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Models
{
    public partial class Solicitud
    {
        [Key]
        public int IdSolicitud { get; set; }
        public string NombreSolicitud { get; set; }
        public DateTime FechaCreada { get; set; }
        public string FechaRespuesta { get; set; }
        public int IdSuministro { get; set; }
        public int IdEstado { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Suministro IdSuministroNavigation { get; set; }
    }
}
