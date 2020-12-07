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
        public string EstadoPedido { get; set; }
        public Docente Docente { get; set; }
        public List<DetalleFormulario> detalleFormulario { get; set; }
        public Empleado empleado { get; set; }
        public string NombreAsignatura { get; set; }
        public string GrupoAsignatura { get; set; }
        public string HoraAsignatura { get; set; }


        public Formulario()
        {
            EstadoPedido = "Pendiente";
            Docente = new Docente();
            detalleFormulario = new List<DetalleFormulario>();
            empleado = new Empleado();
            
        }



       
      
    }
}
