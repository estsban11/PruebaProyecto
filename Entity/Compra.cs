using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Compra
    {
        public double SubTotal { get; set; }
        public double IVA { get; set; }
        public double Total { get; set; }
        
        public Compra()
        {
             SubTotal = 0;
             IVA = 0;
             Total = 0;

        }
        private void CalcularSubtotal(List<MaterialMonitor> lista)
        {
           
            foreach (MaterialMonitor material in lista)
            {
                SubTotal = SubTotal + (material.PrecioProducto * material.CantidadProducto);
            }

        }
        private void CalcularIVA(List<MaterialMonitor> lista)
        {
            foreach (MaterialMonitor material in lista)
            {
                IVA = IVA + (material.PrecioProducto * material.CantidadProducto * 0.16);
            }
        }
        public void CalcularPagoTotal(List<MaterialMonitor> lista)
        {
            CalcularSubtotal(lista);
            CalcularIVA(lista);
            Total = SubTotal + IVA;
        }

    }
}
