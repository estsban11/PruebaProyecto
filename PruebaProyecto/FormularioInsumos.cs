using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Entity;
using BLL;

namespace PruebaProyecto
{
    public partial class FormularioInsumos : Form
    {
        List<MaterialMonitor> materiales = new List<MaterialMonitor>();
        PedidoMonitorServiceBD serviceBD;
        public FormularioInsumos()
        {
            InitializeComponent();
            serviceBD = new PedidoMonitorServiceBD(ExtraerCadena.connectionString);
         }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        

        private void button1_Click(object sender, EventArgs e)
        {
            GuardarPedido();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormularioInsumos_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = txtDescripcion.Text;
            dataGridView1.Rows[n].Cells[1].Value = txtMarca.Text;
            dataGridView1.Rows[n].Cells[2].Value = txtCantidad.Text;
            dataGridView1.Rows[n].Cells[3].Value = txtPrecio.Text;
        }

        public void GuardarPedido()
        {
            PedidoMonitor pedidoMonitor = new PedidoMonitor();
            pedidoMonitor.IdPedido = txtNoPedido.Text;
            pedidoMonitor.Fecha = dtpFechaPedido.Value;
            pedidoMonitor.Descripcion = txtDescripcion.Text;
            pedidoMonitor.Materiales = ListaMateriales();
            pedidoMonitor.Compra.CalcularPagoTotal(pedidoMonitor.Materiales);
            MessageBox.Show(serviceBD.GuardarPedido(pedidoMonitor), "Guardar", MessageBoxButtons.OK);
        }

        public List<MaterialMonitor> ListaMateriales()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                MaterialMonitor materialMonitor = new MaterialMonitor();
                materialMonitor.DescripcionProducto= Convert.ToString(row.Cells["Descripcion"].Value);
                materialMonitor.MarcaProducto = Convert.ToString(row.Cells["Marca"].Value);
                materialMonitor.CantidadProducto = Convert.ToInt32(row.Cells["Cantidad"].Value);
                materialMonitor.PrecioProducto = Convert.ToDouble(row.Cells["Precio"].Value);
                materialMonitor.IdPedido = txtNoPedido.Text;
                materiales.Add(materialMonitor);
            }
            return materiales;
        }
    }
}
