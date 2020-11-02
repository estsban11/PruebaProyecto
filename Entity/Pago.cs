using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Pago
    {
        List<Pedido> listaDePedidos { get; set; }
        public double subtotal{ get; set; }
        public double IVA { get; set; }
        public double total { get; set; }

        public void CalcularPago()
        {
            if(listaDePedidos != null)
            {
                subtotal = listaDePedidos.Sum(m => m.materiales.precioProducto);
                IVA = subtotal * 0.16;
                total = subtotal + IVA;
            }
        }

    }
}
