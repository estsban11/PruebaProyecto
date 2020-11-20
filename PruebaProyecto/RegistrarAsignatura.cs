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
    public partial class RegistrarAsignatura : Form
    {

        public int xClick = 0;
        public int yClick = 0;
        AsignaturaServiceBD service;
        public RegistrarAsignatura()
        {
            InitializeComponent();
            service = new AsignaturaServiceBD(ExtraerCadena.connectionString);
            this.Opacity = 0.97;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistrarAsignatura_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button!= MouseButtons.Left)
            {
                xClick = e.X;
                yClick = e.Y;
            }
            else
            {
                this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Asignatura asignatura = new Asignatura();
            asignatura.CodigoMateria = textBox1.Text;
            asignatura.NombreMateria = textBox2.Text;
            asignatura.NumeroGrupo = textBox3.Text;
            asignatura.HorasLaboratorio = textBox4.Text;
            asignatura.Docente.Identificacion = textBox5.Text;
            MessageBox.Show(service.Guardar(asignatura), "Registro", MessageBoxButtons.OK);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
