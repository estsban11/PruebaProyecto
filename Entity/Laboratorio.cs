using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Laboratorio
    {
        public string IdLaboratorio { get; set; }
        public string Ubicacion { get; set; }
        public List<Empleado> Empleados { get; set; }
        public List<Material> Materiales { get; set; }
        public List<Cargo> Cargos { get; set; }
    }
}
