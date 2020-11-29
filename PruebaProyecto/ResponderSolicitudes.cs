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
    public partial class ResponderSolicitudes : Form
    {
        public int xClick = 0;
        public int yClick = 0;
        MaterialServiceBD serviceBD;

        public ResponderSolicitudes()
        {
            InitializeComponent();
            serviceBD = new MaterialServiceBD(ExtraerCadena.connectionString);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResponderSolicitudes_MouseMove(object sender, MouseEventArgs e)
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

        private void textBox1_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<MaterialAdministrador> materiales = new List<MaterialAdministrador>();
            MaterialAdministrador material = serviceBD.Buscar(textBox1.Text);
            materiales.Add(material);
            dataGridView1.DataSource = materiales;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarStock() == true)
            {
                MessageBox.Show(serviceBD.ActualizarEstadoMaterial(textBox2.Text, comboBox1.Text), "Actualizar", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("La cantidad pedida supera a la cantidad en stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public bool ValidarStock()
        {
            int cantidadPedida, cantidadDisponible;
            cantidadPedida = int.Parse(textBox4.Text);
            cantidadDisponible = int.Parse(textBox6.Text);
            if (cantidadPedida > cantidadDisponible)
            {
                return false;
            }else if (cantidadDisponible == cantidadPedida)
            {
                return true;
            }
            else
            {
                return true;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
