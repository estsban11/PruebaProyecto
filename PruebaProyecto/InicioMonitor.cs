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

namespace PruebaProyecto
{
    public partial class InicioMonitor : Form
    {
        FormularioServiceBD serviceBD;
        public InicioMonitor()
        {
            InitializeComponent();
            serviceBD = new FormularioServiceBD(ExtraerCadena.connectionString);
            LlenarPendiente();
        }

        public void LlenarPendiente()
        {
            var busqueda = serviceBD.BuscarFormularioPendiente().Encontrado;
            if (busqueda == true)
            {
                Formulario formulario = serviceBD.BuscarFormularioPendiente().formulario;
                FechaP.Text = formulario.FechaPedido.ToString();
                FechaL.Text = formulario.FechaLimite.ToString();
                docente.Text = formulario.Docente.primerNombre;
                materia.Text = formulario.NombreAsignatura;
                horario.Text = formulario.HoraAsignatura;
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            


        }

        private void panel1_Click(object sender, EventArgs e)
        {

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            

        }
        
    }
}
