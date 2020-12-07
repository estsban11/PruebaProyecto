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
    public partial class ActualizarProductos : Form
    {
        MaterialServiceBD serviceBD;
        public int xClick { get; set; }
        public int yClick { get; set; }
        public ActualizarProductos()
        {
            InitializeComponent();
            serviceBD = new MaterialServiceBD(ExtraerCadena.connectionString);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistrarAsignatura_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void ActualizarProductos_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                xClick = e.X;
                yClick = e.Y;
            }
            else
            {
                this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick);
            }

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(serviceBD.Actualizar(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32( textBox4.Text)), "Actualizar", MessageBoxButtons.OK);
        }
    }
}
