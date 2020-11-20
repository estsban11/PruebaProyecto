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
    public partial class PrincipalDocente : Form, Interface1
    {

        public string texto;
     
        
        public PrincipalDocente()
        {
            InitializeComponent();
            this.Opacity = 0.91;
            OcultarSubmenu();
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            CopiarTexto(new FormularioDocente());
            AbrirForm(new FormularioDocente());
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
            
        }

        private void CerrarFormularios()
        {
            var form = new PrincipalDocente();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            RegistrarAsignatura diligenciar = new RegistrarAsignatura();
            diligenciar.Hide();
            diligenciar.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Esta seguro de cerrar la aplicacion?", "", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void CopiarTexto(FormularioDocente docente)
        {
        }


        private void PrincipalDocente_Load(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormularioDocente());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            MostrarBusmenu(panel4);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Esta seguro de cerrar la aplicacion?", "", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Docente docente = new Docente();
            label1.Text = docente.primerNombre;
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
        }
    }
}
