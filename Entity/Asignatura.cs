using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Asignatura
    {
        public Docente docente { get; set; }
        public string codigoMateria { get; set; }
        public string nombreMateria { get; set; }
        public string numeroGrupo { get; set; }
      
    }
}
