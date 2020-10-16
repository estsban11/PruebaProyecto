using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto
    {
        public Laboratorio Laboratorio { get; set; }
        public string codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public int cantidadProducto { get; set; }
        public double precioProducto { get; set; }

    }
}
