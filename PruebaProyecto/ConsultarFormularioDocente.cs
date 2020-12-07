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
    public partial class ConsultarFormularioDocente : Form
    {
        FormularioServiceBD serviceBD;
        public ConsultarFormularioDocente()
        {
            InitializeComponent();
            serviceBD = new FormularioServiceBD(ExtraerCadena.connectionString);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Formulario formulario = new Formulario();

            var busqueda = serviceBD.BuscarFormulario(textBox10.Text).Encontrado;
            if (busqueda == true)
            {
                formulario = serviceBD.BuscarFormulario(textBox10.Text).formulario;
                textBox2.Text = formulario.Docente.Identificacion;
                textBox3.Text = formulario.Docente.primerNombre;
                textBox5.Text = formulario.NombreAsignatura;
                textBox7.Text = formulario.GrupoAsignatura;
                textBox6.Text = formulario.HoraAsignatura;
                textBox8.Text = formulario.FechaPedido.ToString();
                textBox9.Text = formulario.FechaLimite.ToString();
                textBox1.Text = formulario.EstadoPedido;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = serviceBD.BuscarMateriales(textBox10.Text);
            }
            else
            {
                MessageBox.Show(serviceBD.BuscarFormulario(textBox10.Text).Mensaje, "Error", MessageBoxButtons.OK);
            }
        }
    }
}
