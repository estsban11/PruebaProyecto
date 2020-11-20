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
using BLL;




namespace PruebaProyecto
{
    public partial class Login : Form
    {
        public CambiarColor color = new CambiarColor();
        DialogResult resultNegro;
        DialogResult resultBlanco;
        DocenteService service = new DocenteService();
        EmpeladoServiceBD serviceBD;
       
        public Login()
        {
            InitializeComponent();
            serviceBD = new EmpeladoServiceBD(ExtraerCadena.connectionString);
            
        }
        
        
        public bool validarCampos()
        {
            bool vacio = true;

            if(textBox1.Text == "")
            {
                vacio = false;
                errorProvider1.SetError(textBox1, "Ingesa nombre de usuario");
            }
            if(textBox2.Text == "")
            {
                vacio = false;
                errorProvider1.SetError(textBox2, "Ingresa contraseña");
            }

            return vacio;
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (validarCampos() == false)
            {
                ValidarCargo();
                this.Hide();
            }
            
        }
    private void ValidarCredenciales(string nombreUsuario)
        {
            var busqueda = serviceBD.ValidarNombreUsuario(nombreUsuario);
           
            if (busqueda.Encontrado == false)
            {
              
                PrincipalAdministrador admin = new PrincipalAdministrador();
                admin.Show();
            }
            else
            {
                MessageBox.Show("Nombre de usuario invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void Buscar(string nombreUsuario)
        {
           var busqueda =  service.Busqueda(nombreUsuario);
            if (busqueda.Encontrado==true)
            {
                ValidarCargo();
                
            }
            else
            {
                MessageBox.Show(busqueda.Mensaje);
            }


        }
        private void ValidarCargo()
        {
            
            if (textBox1.Text[0] == 'A')
            {
                PrincipalAdministrador principal = new PrincipalAdministrador();
               
                principal.Show();
                
            }
            else if (textBox1.Text[0] == 'D')
            {
                PrincipalDocente docente = new PrincipalDocente();
                docente.Show();
              

            }
            else if (textBox1.Text[0] == 'M')
            {
                PrincipalMonitor monitor = new PrincipalMonitor();
                monitor.Show();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

           

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
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

        public void PasarTexto()
        {
           
           

        }
        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Esta seguro de cerrar la aplicacion?", "", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            resultBlanco = 0;
            resultBlanco = MessageBox.Show("Se cambiara el color del programa", "Color", MessageBoxButtons.YesNo);
            iconButton3.Visible = true;
            iconButton2.Visible = false;
            color.ValidarColorBlanco(resultBlanco);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            resultNegro = 0;
            resultNegro = MessageBox.Show("Se cambiara el color del programa", "Color", MessageBoxButtons.YesNo);
            iconButton2.Visible = true;
            iconButton3.Visible = false;
            color.ValidarColorNegro(resultNegro);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Ingrese nombre de usuario");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                
                errorProvider1.SetError(textBox2, "Ingrese contraseña");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }
    }
    }

