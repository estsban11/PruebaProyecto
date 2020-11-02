using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Monitor :  Trabajador
    {
        public Pedido pedidos { get; set; }
    }
}
