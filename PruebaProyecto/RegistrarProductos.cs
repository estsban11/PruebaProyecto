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
        List<MaterialAdministrador> materiales = new List<MaterialAdministrador>();
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

            if (ValidarCampos())
            {
                MaterialAdministrador material = new MaterialAdministrador();
                material.NombreProducto = txtNombre.Text;
                material.DescripcionProducto = txtDescripcion.Text;
                material.CantidadProducto = int.Parse(txtCantidad.Text);
                MessageBox.Show(service.RegistrarMateriales(material), "Registro", MessageBoxButtons.OK);
                ConsultarMateriales();
                LimpiarCampos();
                errorProvider1.Clear();
                
            }
            else
            {
                MessageBox.Show("Campo(s) vacio(s)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        public void ConsultarMateriales()
        {
            dataGridView1.Rows.Clear();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            ConsultarMateriales();

        }

        private bool ValidarCampos()
        {
            bool vacio = true;

            if (txtNombre.Text == "")
            {
                vacio = false;
                errorProvider1.SetError(txtNombre, "Ingrese el nombre del producto");
            }
            if (txtDescripcion.Text == "")
            {
                vacio = false;
                errorProvider1.SetError(txtDescripcion, "Ingrese la descripcion del producto");
            }
            if (txtCantidad.Text == "")
            {
                vacio = false;
                errorProvider1.SetError(txtCantidad, "Ingrese la cantidad del producto");
            }
           
            return vacio;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNombre_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                errorProvider1.SetError(txtNombre, "Ingrese el nombre del producto");
            }
            else
            {
                errorProvider1.SetError(txtNombre, "");
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                errorProvider1.SetError(txtDescripcion, "Ingrese la descripcion del producto");
            }
            else
            {
                errorProvider1.SetError(txtDescripcion, "");
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                errorProvider1.SetError(txtCantidad, "Ingrese la cantidad del producto");
            }
            else
            {
                errorProvider1.SetError(txtCantidad, "");
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            
        }
            
        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
