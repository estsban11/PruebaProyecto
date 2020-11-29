using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DetalleFormulario
    {
        public DetalleFormulario()
        {
           
            Devuelto = "pendiente";
        }
        public string idProducto { get; set; }
        public string NombreMaterial { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Devuelto { get; set; }
        public string idFormulario { get; set; }

       
    }
}
