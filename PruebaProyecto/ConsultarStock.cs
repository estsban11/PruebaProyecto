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
    public partial class ConsultarStock : Form
    {

        MaterialServiceBD serviceBD;
        public ConsultarStock()
        {
            InitializeComponent();
            serviceBD = new MaterialServiceBD(ExtraerCadena.connectionString);
            LLenarTabla();
        }

        public void LLenarTabla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = serviceBD.Consulta().Materiales;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="Mayor stock")
            {
                dataGridView1.DataSource = serviceBD.FiltrarMayorStock();
            }
            if(comboBox1.Text =="Menor stock")
            {
                dataGridView1.DataSource = serviceBD.FiltrarMenorStock();

            }
        }

        private void ConsultarStock_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<MaterialAdministrador> materiales = new List<MaterialAdministrador>();
             MaterialAdministrador material = serviceBD.Buscar(textBox1.Text);
            materiales.Add(material);
            dataGridView1.DataSource = materiales;
            if(textBox1.Text=="")
                dataGridView1.DataSource = serviceBD.Consulta().Materiales;
        }
    }
}
