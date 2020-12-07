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
        DocenteserviceBD docenteserviceBD;
       
        public Login()
        {
            InitializeComponent();
            serviceBD = new EmpeladoServiceBD(ExtraerCadena.connectionString);
            docenteserviceBD = new DocenteserviceBD(ExtraerCadena.connectionString);
            
        }
        
        
        public bool validarCampos()
        {
            bool vacio = true;

            if(textBox1.Text == "")
            {
                vacio = false;
                errorProvider1.SetError(textBox1, "Ingresa nombre de usuario");
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
            
            if (validarCampos())
            {
                if (textBox1.Text[0] == 'D')
                {
                    validarDocente(textBox1.Text, textBox2.Text);
                }
                else
                {
                    ValidarCredenciales(textBox1.Text, textBox2.Text);
                }
            }
            
        }

        public void PasarTextoDocente(PrincipalDocente docente)
        {
         
        }
       public void validarDocente(string nombreUsuario, string Contraseña)
        {
            var NombreUsuario = docenteserviceBD.ValidarNombreUsuario(nombreUsuario);
            var contraseña = docenteserviceBD.ValidarContraseña(Contraseña);
            if (NombreUsuario.Encontrado == true)
            {
                if (contraseña.Encontrado == true)
                {
                    var Usuario = contraseña.Docente;
                    PrincipalDocente principal = new PrincipalDocente();
                    principal.label3.Text = Usuario.Identificacion;
                    principal.textBox1.Text = Usuario.Identificacion;
                    principal.textBox1.Visible = false;
                    principal.Show();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta", "Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(NombreUsuario.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            
       private void ValidarCredenciales(string nombreUsuario, string Contraseña)
        {
            var contraseña = serviceBD.ValidarContraseña(Contraseña);
            var busqueda = serviceBD.ValidarNombreUsuario(nombreUsuario);

            if (busqueda.Encontrado == true)
            {
                
                if (contraseña.Encontrado == true)
                {
                    var Usuario = busqueda.Empleado;
                    ValidarCargo(Usuario);
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta", "Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Nombre de usuario invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            }

        private static void PasarUsuario(BuscarEmpleado busqueda)
        {
            var Usuario = busqueda.Empleado;
            PrincipalAdministrador admin = new PrincipalAdministrador();
            admin.label3.Text = $"{Usuario.PrimerNombre} {Usuario.PrimerApellido}";
        }

        public void Nombre(Empleado empleado)
        {
            PrincipalAdministrador principalAdministrador = new PrincipalAdministrador();
            principalAdministrador.label3.Text = $"{empleado.PrimerNombre} {empleado.PrimerApellido}";
        }
       
        private void ValidarCargo(Empleado empleado)
        {

            if (textBox1.Text[0] == 'A')
            {
                PrincipalAdministrador principal = new PrincipalAdministrador();
                principal.label3.Text = empleado.PrimerNombre;
                principal.textBox1.Text = empleado.Cedula;
                principal.Show();

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

