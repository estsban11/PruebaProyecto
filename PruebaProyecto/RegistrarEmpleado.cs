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
    public partial class RegistrarEmpleado : Form
    {
        EmpeladoServiceBD service;
        public RegistrarEmpleado()
        {
            InitializeComponent();
            service = new EmpeladoServiceBD(ExtraerCadena.connectionString);
        }

        private void btRegistrarAsignatura_Click(object sender, EventArgs e)
        {

        }

        public void Registrar()
        {
            Empleado empleado = new Empleado();
            
            empleado.Cedula = txtIdentificacion.Text;
            empleado.PrimerNombre = txtPrimerNombre.Text;
            empleado.SegundoNombre = txtSeguundoNombre.Text;
            empleado.PrimerApellido = txtPrimerApellido.Text;
            empleado.SegundoApellido = txtSegundoApellido.Text;
            empleado.Cargo.IdCargo = txtCargo.Text;
            empleado.Cargo.NombreCargo = comboBox1.Text;
            empleado.Email = txtEmail.Text;
            empleado.NombreUsuario = txtNombreUsuario.Text;
            empleado.Contraseña = txtContraseña.Text;
            MessageBox.Show(service.Guardar(empleado), "Registrar", MessageBoxButtons.OK);
        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Administrador")
            {
                txtCargo.Text = "001";
                txtNombreUsuario.Text = $"AD{txtIdentificacion.Text}";
            }
            else
            {
                txtCargo.Text = "002";
                txtNombreUsuario.Text = $"MT{txtIdentificacion.Text}";
            }
        }
    }
}
