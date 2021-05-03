using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosHumanos.Models
{
    public class Usuario:IdentityUser
    {
        public int NDocumento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public int? IdEstado { get; set; }
        public int? IdSolicitud { get; set; }

        //public virtual Estado IdEstadoNavigation { get; set; }
        //public virtual Solicitud IdSolicitudNavigation { get; set; }
    }
}
