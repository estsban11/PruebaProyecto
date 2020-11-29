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
        FormularioServiceBD FormularioServiceBD;
        List<DetalleFormulario> detalles = new List<DetalleFormulario>();
        EmpeladoServiceBD service;
        AsignaturaServiceBD asignaturaServiceBD;
       


        public FormularioDocente()
        {
           
            InitializeComponent();
            serviceBD = new DocenteserviceBD(ExtraerCadena.connectionString);
            FormularioServiceBD = new FormularioServiceBD(ExtraerCadena.connectionString);
            service = new EmpeladoServiceBD(ExtraerCadena.connectionString);
            asignaturaServiceBD = new AsignaturaServiceBD(ExtraerCadena.connectionString);
            ExtraerTexto(); 
            LlenarCombo();
          
        }

       

        public void LlenarCombo()
        {
            var lista = service.ListaMonitores().lista;
            foreach (var item in lista)
            {
                cmbDocentes.Items.Add(item);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombreProducto.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtDescripcion.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            
        }

        public void ExtraerTexto()
        {

            PrincipalDocente doc = new PrincipalDocente();
            txtCodigo.Text = doc.textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            
        }

        public void RegistrarInformacionPedido()
        {
            Formulario formulario = new Formulario();
            formulario.Docente.Identificacion = txtCodigo.Text;
            formulario.empleado.Cedula = cmbDocentes.Text;
            formulario.FechaPedido = dtpFechaPedido.Value;
            formulario.FechaLimite = dtpFechaEntrega.Value;
            formulario.NombreAsignatura = cmbAsignatura.Text;
            formulario.GrupoAsignatura = cmbGrupo.Text;
            formulario.HoraAsignatura = textBox1.Text;
            formulario.Docente.primerNombre = txtNombreDocente.Text;
            formulario.empleado.PrimerNombre = textBox5.Text;
          
        }

        public void RegistrarMaterialesPedido()
        {
           
        }


        public void llenarComboGrupos(string nombre)
        {
            var lista = asignaturaServiceBD.ListaGruposAsignatura(nombre).Lista;
            foreach (var item in lista)
            {
                cmbGrupo.Items.Add(item);
            }
        }


        public void LlenarComboGrupo(string docente)
        {
            cmbGrupo.Items.Clear();
            SqlConnection connection = new SqlConnection(ExtraerCadena.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand($"select * from asignatura where id_docente = @docente ", connection);
            command.Parameters.Add(@"docente", SqlDbType.VarChar).Value = txtCodigo.Text;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               cmbGrupo.Items.Add(reader[2].ToString());
               
            }
            connection.Close();
        }

        public void LlenarComboAsignatura(string docente)
        {
            var lista = asignaturaServiceBD.ListaAsignaturas(docente).Lista;
            foreach (var item in lista)
            {
                cmbAsignatura.Items.Add(item);
            }
        }

        public void ExtraerIdMonitor()
        {
            var lista = service.ListaNombresMonitor().lista;
            foreach (var item in lista)
            {
                
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(txtCodigo.Text == "")
            {
                cmbAsignatura.Items.Clear();
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
                textBox5.Text = service.Monitor(cmbDocentes.Text);
            }
        }

        public void LlenarNumeroFormulario(int Contar)
        {
            
            
        }

        private void btFinalizar_Click(object sender, EventArgs e)
        {
            Formulario formulario = new Formulario();
            formulario.IdFormulario = textBox2.Text;
            formulario.Docente.Identificacion = txtCodigo.Text;
            formulario.empleado.Cedula = cmbDocentes.Text;
            formulario.FechaPedido = dtpFechaPedido.Value;
            formulario.FechaLimite = dtpFechaEntrega.Value;
            formulario.NombreAsignatura = cmbAsignatura.Text;
            formulario.GrupoAsignatura = cmbGrupo.Text;
            formulario.HoraAsignatura = textBox1.Text;
            formulario.Docente.primerNombre = txtNombreDocente.Text;
            formulario.empleado.PrimerNombre = textBox5.Text;
            formulario.detalleFormulario = LLenarLista();
            MessageBox.Show(FormularioServiceBD.GuardarPedido(formulario), "guardar", MessageBoxButtons.OK);
            
        }


        public List<DetalleFormulario> LLenarLista()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DetalleFormulario detalle = new DetalleFormulario();
                detalle.NombreMaterial = Convert.ToString(  row.Cells["NombreProducto"].Value);
                detalle.Descripcion = Convert.ToString( row.Cells["Descripcion"].Value);
                detalle.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                detalle.idFormulario = textBox2.Text;
                detalles.Add(detalle);
            }
            return detalles;
        }
        public List<DetalleFormulario> Pedidos(Formulario formulario)
        {
            foreach (var item in detalles)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                item.NombreMaterial = row.Cells["NombreProducto"].Value.ToString();
                item.Descripcion = row.Cells["Descripcion"].Value.ToString();
                item.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                item.idFormulario = textBox2.Text;
                 detalles.Add(item);
                }
            }
            return detalles;
        }
        

        private void Agregar_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = txtNombreProducto.Text;
            dataGridView1.Rows[n].Cells[1].Value = txtDescripcion.Text;
            dataGridView1.Rows[n].Cells[2].Value = txtCantidad.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            
        }

        private void cmbAsignatura_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAsignatura.Text == "")
            {
                cmbGrupo.Items.Clear();
            }
            else
            {
                LlenarComboGrupo(cmbAsignatura.Text);
            }
        }
    }
}
