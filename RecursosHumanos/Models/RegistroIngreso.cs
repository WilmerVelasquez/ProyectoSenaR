using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Models
{
    public partial class RegistroIngreso
    {
        [Key]
        public int IdRegistro { get; set; }
        public string NombreRegistro { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int IdUsuario { get; set; }
        public int IdHorario { get; set; }

        public virtual Horario IdHorarioNavigation { get; set; }
    }
}
