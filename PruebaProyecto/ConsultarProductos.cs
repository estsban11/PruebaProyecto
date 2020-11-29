using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;

namespace PruebaProyecto
{
    public partial class ConsultarProductos : Form
    {
        MaterialServiceBD service;
        public ConsultarProductos()
        {
            InitializeComponent();
            service = new MaterialServiceBD(ExtraerCadena.connectionString);
            LlenarTabla();
        }

        public void LlenarTabla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = service.Consulta().Materiales;
           

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ActualizarProductos actualizar = new ActualizarProductos();
            actualizar.ShowDialog();
            actualizar.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            actualizar.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            actualizar.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            actualizar.numericUpDown1.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[3].Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BuscarMaterial();
        }

        private void BuscarMaterial()
        {
            List<MaterialAdministrador> materiales = new List<MaterialAdministrador>();
            MaterialAdministrador material = service.Buscar(textBox1.Text);
            materiales.Add(material);
            dataGridView1.DataSource = materiales;
            if (textBox1.Text == "")
                dataGridView1.DataSource = service.Consulta().Materiales;
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            BuscarMaterial();
        }

        private void textBox1_TextAlignChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            BuscarMaterial();
        }
    }
}
