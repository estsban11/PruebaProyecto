using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class RespuestaSolicitud
    {
        public string IdFormulario { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public  string Estado { get; set; }
        public int Cantidad { get; set; }
        public string IdSolicitud { get; set; }


    }
}
