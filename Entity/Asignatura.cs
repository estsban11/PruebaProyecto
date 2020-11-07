using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Asignatura
    {
        public string IdAsignatura { get; set; }
        public string NombreAsignatura { get; set; }
        public int NumeroGrupo { get; set; }
        public string HorasLaboratorio { get; set; }
        public Docente docente { get; set; }
    }
}
