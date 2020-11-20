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
        public DateTime FechaPedido{ get; set; }
        public DateTime FechaLimite { get; set; }
        public Docente Docente { get; set; }
        public Material Material { get; set; }
        public Empleado empleado { get; set; }

        public Formulario()
        {
            Docente = new Docente();
            Material = new Material();
            empleado = new Empleado();
        }
    }
}
