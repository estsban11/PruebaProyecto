using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Administrador
    {
        public Laboratorio laboratorio { get; set; }
        public string codigoAdministrador { get; set; }
        public  string nombreDeUsuario { get; set;}
        public string contraseña { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string Identificacion { get; set; }
       
    }
}
