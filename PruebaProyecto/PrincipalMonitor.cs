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
            Bordes();
            OcultarSubmenu();
            
        }

        public void Bordes()
        {
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormularioInsumos());
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
    }
}
