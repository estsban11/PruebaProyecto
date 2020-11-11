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


namespace PruebaProyecto
{
    public partial class Registrar : Form
    {

    
        Login login = new Login();
        CambiarColor color = new CambiarColor();
        public Registrar()
        {
         InitializeComponent();
        
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
