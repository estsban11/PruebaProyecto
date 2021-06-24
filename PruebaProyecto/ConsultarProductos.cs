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
        List<MaterialAdministrador> materiales = new List<MaterialAdministrador>();
        public ConsultarProductos()
        {
            InitializeComponent();
            service = new MaterialServiceBD(ExtraerCadena.connectionString);
            LlenarTabla();
        }

        public void LlenarTabla()
        {
      
            materiales = service.Consulta().Materiales;
            foreach (var item in materiales)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item.CodigoProducto;
                dataGridView1.Rows[n].Cells[1].Value = item.NombreProducto;
                dataGridView1.Rows[n].Cells[2].Value = item.DescripcionProducto;
                dataGridView1.Rows[n].Cells[3].Value = item.CantidadProducto;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ActualizarProductos actualizar = new ActualizarProductos();
            actualizar.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            actualizar.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            actualizar.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
           actualizar.textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            actualizar.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void BuscarMaterial()
        {

            MaterialAdministrador material = service.BuscarMaterial(textBox1.Text).Material;
            var busqueda = service.BuscarMaterial(textBox1.Text).Error;
            if (busqueda == true)
            {
                dataGridView1.Rows[0].Cells[0].Value = material.CodigoProducto;
                dataGridView1.Rows[0].Cells[1].Value = material.NombreProducto;
                dataGridView1.Rows[0].Cells[2].Value = material.DescripcionProducto;
                dataGridView1.Rows[0].Cells[3].Value = material.CantidadProducto;
            }
            else
            {
                MessageBox.Show(service.BuscarMaterial(textBox1.Text).Mensaje, "", MessageBoxButtons.OK);
                LlenarTabla();
            }

            if (textBox1.Text == "")
            {
                dataGridView1.Rows.Clear();
                LlenarTabla();
            }
          

            
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void textBox1_TextAlignChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void textBox1_TabStopChanged(object sender, EventArgs e)
        {
           
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            BuscarMaterial();
        }
    }
}
