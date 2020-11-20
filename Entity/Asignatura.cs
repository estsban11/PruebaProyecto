using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Asignatura
    {
        public Docente Docente { get; set; }
        public string CodigoMateria { get; set; }
        public string NombreMateria { get; set; }
        public string NumeroGrupo { get; set; }
        public string HorasLaboratorio { get; set; }

        public Asignatura()
        {
            Docente = new Docente();
        }
      
    }
}
