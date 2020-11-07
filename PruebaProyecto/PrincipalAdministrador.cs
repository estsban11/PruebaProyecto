using Entity;
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
    public partial class PrincipalAdministrador : Form
    {
        public PrincipalAdministrador()
        {
            InitializeComponent();
            Bordes();
        }

        private void Bordes()
        {
            button3.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.BorderSize = 0;
            button6.FlatAppearance.BorderSize = 0;
            button7.FlatAppearance.BorderSize = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        public void Registrar()
        {
            
            
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
        private void button3_Click(object sender, EventArgs e)
        {
          
            DialogResult resultado = MessageBox.Show("¿Esta seguro de cerrar la aplicacion?", "", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
          

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AbrirForm(new RegistrarProductos());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirForm(new ConsultarProductos());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
    }
}
