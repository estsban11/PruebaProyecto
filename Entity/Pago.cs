﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Pago
    {
        public Pedido Pedido { get; set; }
        public double SubTotal { get; set; }
        public double IVA { get; set; }
        public double Total { get; set; }
        public Pago()
        {
            SubTotal = 0;
            IVA = 0;
            Total = 0;
        }
        private void CalcularSubtotal()
        {
            foreach (Material material in Pedido.Materiales)
            {
                SubTotal = SubTotal + (material.precioProducto * material.cantidadProducto);
            }

        }
        private void CalcularIVA()
        {
            foreach (Material material in Pedido.Materiales)
            {
                IVA = IVA + (material.precioProducto * material.cantidadProducto * 0.16);
            }
        }
        public void CalcularPagoTotal()
        {
            CalcularSubtotal();
            CalcularIVA();
            Total = SubTotal + IVA;
        }

    }
}
