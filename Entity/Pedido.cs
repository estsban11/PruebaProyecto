using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Pedido
    {
        public string IdPedido { get; set; }
        public DateTime Fecha { get; set; }
        public List<Material> Materiales { get; set; }
        public Pago  Pago { get; set; }
    }
}
