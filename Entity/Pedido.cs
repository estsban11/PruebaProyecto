using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Pedido
    {
        public Material materiales { get; set; }
        public DateTime fechaPedido { get; set; }
        public DateTime duracionPedido { get; set; }

    }
}
