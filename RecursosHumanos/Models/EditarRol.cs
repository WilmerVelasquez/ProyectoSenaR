using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosHumanos.Models
{
    public class EditarRol
    {
        public string Id { get; set; }
        public EditarRol()
        {
            Usuario = new List<string>();
        }
        [Required (ErrorMessage="El Nombre de rol es obligatorio")]
        public string NombreRol { get; set; }
        public List<string> Usuario { get; set; }
    }
}
