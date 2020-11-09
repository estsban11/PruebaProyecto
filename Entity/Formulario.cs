using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Formulario
    {
        public string IdFormulario { get; set; }
        public DateTime Fecha { get; set; }
        public Docente Docente { get; set; }
    }
}
