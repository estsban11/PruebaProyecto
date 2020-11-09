using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaProyecto
{
    public partial class ConsultarProductos : Form
    {
        public ConsultarProductos()
        {
            InitializeComponent();
            
            LlenarTabla();
        }

        public void LlenarTabla()
        {
            dataGridView1.Rows.Insert(0, "10001", "Alcohol", "litro", 2);
           

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ActualizarProductos actualizar = new ActualizarProductos();
            actualizar.Show();
            actualizar.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            actualizar.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            actualizar.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            actualizar.numericUpDown1.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[3].Value);
        }
    }
}
