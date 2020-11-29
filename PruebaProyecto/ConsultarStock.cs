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
    }
}
