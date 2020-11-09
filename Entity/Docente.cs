using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Docente
    {
       
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string nombreDeUsuario { get; set; }
        public string contraseña { get; set; }
        public string Identificacion { get; set; }
        public string nombreCargo { get; set; }
        public string Email { get; set; }
        public Asignatura asignatura { get; set; }
    }
}
