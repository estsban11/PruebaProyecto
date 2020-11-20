using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;
using System.Data.SqlClient;

namespace PruebaProyecto
{
    public partial class RegistrarProductos : Form
    {
        MaterialServiceBD service;
        public RegistrarProductos()
        {
            InitializeComponent();
            service = new MaterialServiceBD(ExtraerCadena.connectionString);
            ConsultarMateriales();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Material material = new Material();
            material.CodigoProducto = txtCodigo.Text;
            material.NombreProducto = txtNombre.Text;
            material.DescripcionProducto = txtDescripcion.Text;
            material.CantidadProducto = int.Parse(txtCantidad.Text);
            material.PrecioProducto = int.Parse( txtPrecio.Text);
            MessageBox.Show(service.RegistrarMateriales(material), "Registro", MessageBoxButtons.OK);
            ConsultarMateriales();
        }

        public void ConsultarMateriales()
        {

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = service.Consulta().Materiales;
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ConsultarMateriales();
           
        }
    }
}
