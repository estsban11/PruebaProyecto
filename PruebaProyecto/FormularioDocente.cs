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
using System.Data.SqlClient;
using BLL;

namespace PruebaProyecto
{
    public partial class FormularioDocente : Form
    {
        DocenteserviceBD serviceBD;
        
        public FormularioDocente()
        {
           
            InitializeComponent();
            serviceBD = new DocenteserviceBD(ExtraerCadena.connectionString);
            LlenarTabla();
            LlenarComboMonitor();
           
            
        }

        public void LlenarTabla()
        {
            dataGridView1.Rows.Insert(0,"Mortero","delgado",2);
            dataGridView1.Rows.Insert(1, "Alcohol", "por litro", 2);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombreProducto.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtDescripcion.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            
        }

        public void Buscar()
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            
        }

        public void LlenarComboMonitor()
        {
            cmbDocentes.Items.Clear();
            SqlConnection connection = new SqlConnection(ExtraerCadena.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("select * from empleado where id_cargo = 002", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbDocentes.Items.Add(reader[0].ToString());
            }
            connection.Close();
        }

        public void LlenarComboAsignatura(string docente)
        {
            cmbAsignatura.Items.Clear();
            SqlConnection connection = new SqlConnection(ExtraerCadena.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand($"select * from asignatura where id_docente = @docente ", connection);
            command.Parameters.Add(@"docente", SqlDbType.VarChar).Value = txtCodigo.Text;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbAsignatura.Items.Add(reader[1].ToString());
            }
            connection.Close();
        }

        public void ExtraerIdMonitor()
        {
            SqlConnection connection = new SqlConnection(ExtraerCadena.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand($"select * from empleado where identificacion = @identificacion   ", connection);
            command.Parameters.Add(@"identificacion", SqlDbType.VarChar).Value = cmbDocentes.Text;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBox5.Text = $"{reader[1]} {reader[3]}";
            }
           
            connection.Close();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(txtCodigo.Text == "")
            {

            }
            else
            {
                LlenarComboAsignatura(txtCodigo.Text);
            }
            
        }

        private void cmbDocentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocentes.Text == "")
            {

            }
            else
            {
                ExtraerIdMonitor();
            }
        }

        public void LlenarNumeroFormulario(int Contar)
        {
            
            
        }

        private void btFinalizar_Click(object sender, EventArgs e)
        {
          
        }
    }
}
