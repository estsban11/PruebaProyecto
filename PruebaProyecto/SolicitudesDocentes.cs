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
    public partial class SolicitudesDocentes : Form
    {
        FormularioServiceBD serviceBD;
        List<MaterialMonitor> materiales = new List<MaterialMonitor>();
        bool Timer;
        public SolicitudesDocentes()
        {
            InitializeComponent();
            serviceBD = new FormularioServiceBD(ExtraerCadena.connectionString);
            llenarComboPendientes();
            
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        public void llenarComboPendientes()
        {
            var lista = serviceBD.FormulariosPendientes().Lista;
            if (lista == null)
            {

            }
            else
            {
                foreach (var item in lista)
                {
                    comboBox2.Items.Add(item);
                }
            }
           
        }
        private void button2_Click(object sender, EventArgs e)
        {

                DatosFormulario(textBox1.Text);

        }

        private void DatosFormulario(string noFormulario)
        {
            Formulario formulario = new Formulario();

            var busqueda = serviceBD.BuscarFormulario(noFormulario).Encontrado;
            if (busqueda == true)
            {
                formulario = serviceBD.BuscarFormulario(noFormulario).formulario;
                textBox2.Text = formulario.Docente.Identificacion;
                textBox3.Text = formulario.Docente.primerNombre;
                textBox5.Text = formulario.NombreAsignatura;
                textBox7.Text = formulario.GrupoAsignatura;
                textBox6.Text = formulario.HoraAsignatura;
                textBox8.Text = formulario.FechaPedido.ToString();
                textBox9.Text = formulario.FechaLimite.ToString();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = serviceBD.BuscarMateriales(noFormulario);
            }
            else
            {
                MessageBox.Show(serviceBD.BuscarFormulario(noFormulario).Mensaje, "Error", MessageBoxButtons.OK);
            }
        }

        public void LlenarTabla(Formulario formulario)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ResponderSolicitudes responderSolicitudes = new ResponderSolicitudes();
            responderSolicitudes.textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            responderSolicitudes.textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            responderSolicitudes.textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            responderSolicitudes.comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            responderSolicitudes.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatosFormulario(comboBox2.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            
            
        }
    }
}
