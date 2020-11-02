using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;

namespace PruebaProyecto
{
    public partial class Registrar : Form
    {

        AdministradorService service;
        Login login = new Login();
        CambiarColor color = new CambiarColor();
        public Registrar()
        {
         InitializeComponent();
         service = new AdministradorService();
            button3.FlatAppearance.BorderSize = 0;
            validarColor();
           
          
        }

        void validarColor()
        {
            if(color.color == true)
            {
                MessageBox.Show("", "");
            }
            else
            {
                color.Blanco();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Close();

           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Administrador administrador = new Administrador();
            administrador.nombreDeUsuario = textBox1.Text;
            administrador.contraseña = textBox6.Text;
            administrador.primerNombre = textBox2.Text;
            administrador.segundoNombre = textBox8.Text;
            administrador.primerApellido = textBox5.Text;
            administrador.segundoApellido = textBox7.Text;
            administrador.Identificacion = textBox3.Text;
            administrador.nombreCargo = comboBox1.Text;
            MessageBox.Show(service.Guardar(administrador),"Registrar");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string final;
            if (comboBox1.Text == "Administrador")
            {
                textBox4.Text = "AD";
                final = textBox4.Text + textBox3.Text;
                textBox1.Text = final;
            }else if(comboBox1.Text == "Docente")
            {
                textBox4.Text = "DC";
                final = textBox4.Text + textBox3.Text;
                textBox1.Text = final;
            }else if (comboBox1.Text == "Monitor")
            {
                textBox4.Text = "MT";
                final = textBox4.Text + textBox3.Text;
                textBox1.Text = final;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
