using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class PedidoMonitor
    {
        public string IdPedido { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public List<MaterialMonitor> Materiales { get; set; }
        public Compra Compra { get; set; }

        public PedidoMonitor()
        {
           this.Ubicacion = "Valledupar";
            Materiales = new List<MaterialMonitor>();
            Compra = new Compra();

        }

        
        
    }
}
