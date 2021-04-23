using PruebaProyecto.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;




namespace PruebaProyecto
{
    public partial class Login : Form
    {
        
        
        public CambiarColor color = new CambiarColor();
        DialogResult resultNegro;
        DialogResult resultBlanco;
        public Login()
        {
            InitializeComponent();
            button3.FlatAppearance.BorderSize = 0;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
           if(textBox1.Text[0] == 'A')
            {
                PrincipalAdministrador principal = new PrincipalAdministrador();
                principal.ShowDialog();
                
            }else if(textBox1.Text[0]== 'D')
            {
                PrincipalDocente docente = new PrincipalDocente();
                docente.ShowDialog();

            }
            else if(textBox1.Text[0]=='M')
            {
                PrincipalMonitor monitor = new PrincipalMonitor();
                monitor.ShowDialog();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registrar registrar = new Registrar();
            this.Hide();
            registrar.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            resultBlanco = 0;
            resultBlanco  =  MessageBox.Show("Color", "Se cambiara el color del programa", MessageBoxButtons.YesNo);
            button5.Visible = true;
            button4.Visible = false;
            color.ValidarColorBlanco(resultBlanco);
            //comentario de compañero de programador

        }

        private void button5_Click(object sender, EventArgs e)
        {
            resultNegro = 0;
            resultNegro = MessageBox.Show("Color", "Se cambiara el color del programa", MessageBoxButtons.YesNo);
            button5.Visible = false;
            button4.Visible = true;
            color.ValidarColorNegro(resultNegro);
        }

        public void ValidarColorNegro(DialogResult dialogoB)
        {
            if (dialogoB== DialogResult.Yes)
            {
                color.Negro();
            }

        }

        public void ValidarColorBlanco(DialogResult dialogoN)
        {

            if (dialogoN == DialogResult.Yes)
            {
                color.Blanco();
            }
        }





    }
}
