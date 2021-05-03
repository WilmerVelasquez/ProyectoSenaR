using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosHumanos.Models
{
    public partial class Horario
    {
        public Horario()
        {
            RegistroIngresos = new HashSet<RegistroIngreso>();
        }
        [Key]
        public int IdHorario { get; set; }
        public string NombreHorario { get; set; }
        public DateTime? HoraInicio { get; set; }
        public DateTime HoraSalida { get; set; }

        public virtual ICollection<RegistroIngreso> RegistroIngresos { get; set; }
    }
}
