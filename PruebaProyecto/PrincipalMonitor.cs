using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaProyecto
{
    public partial class PrincipalMonitor : Form
    {
        public PrincipalMonitor()
        {
            InitializeComponent();
            this.Opacity = 0.91;
            AbrirForm(new InicioMonitor());
            OcultarSubmenu();
            
            
        }

        public void Bordes()
        {
            
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public void AbrirFormConsulta()
        {
            AbrirForm(new SolicitudesDocentes());
        }
        private void AbrirForm(object form)
        {
            if (this.panel3.Controls.Count > 0)
            {
                this.panel3.Controls.RemoveAt(0);
            }
            Form formulario = form as Form;
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(formulario);
            this.panel3.Tag = formulario;
            formulario.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Esta seguro de cerrar la aplicacion?", "", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void OcultarSubmenu()
        {
            panel4.Visible = false;
        }

        private void HideSubMenu()
        {
            if (panel4.Visible)
                panel4.Visible = false;
        }

        private void MostrarBusmenu(Panel panel)
        {
            if (panel.Visible == false)
            {
                HideSubMenu();
                panel.Visible = true;
            }
            else
            {
                panel.Visible = false;
            }
        }

        private void PrincipalMonitor_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            MostrarBusmenu(panel4);
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Esta seguro de cerrar la aplicacion?", "", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormularioInsumos());
        }

        private void button8_Click_1(object sender, EventArgs e)
        {

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            MostrarBusmenu(panel4);
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            AbrirForm(new InicioMonitor());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            AbrirForm(new SolicitudesDocentes());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            AbrirForm(new ConsultarStock());
        }
    }
}
