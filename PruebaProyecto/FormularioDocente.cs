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
using BLL;

namespace PruebaProyecto
{
    public partial class FormularioDocente : Form
    {
        DocenteService service;
        
        public FormularioDocente()
        {
            service = new DocenteService();
            InitializeComponent();
            LlenarTabla();
            Buscar();
          
            
        }

        public void LlenarTabla()
        {
            dataGridView1.Rows.Insert(0,"Mortero","delgado",2);
            dataGridView1.Rows.Insert(1, "Alcohol", "por litro", 2);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            numericUpDown1.Value = Convert.ToDecimal( dataGridView1.CurrentRow.Cells[2].Value);
        }

        public void Buscar()
        {
            var busqueda = service.Busqueda(textBox1.Text);
           if(busqueda.Encontrado == true)
            {
                Docente docente = busqueda.Docente;
                txtNombre.Text = docente.primerNombre;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           Docente docente =  service.Busqueda(textBox1.Text).Docente;
            txtNombre.Text = docente.primerNombre;
            txtApellido.Text = docente.primerApellido;
           // txtAsignatura.Text = docente.asignatura.nombreMateria;
            
            
        }
    }
}
