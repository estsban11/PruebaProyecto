using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class MaterialMonitor
    {
        public string CodigoProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string MarcaProducto { get; set; }
        public int CantidadProducto { get; set; }
        public double PrecioProducto { get; set; }
        public string IdPedido { get; set; }
    }
}
