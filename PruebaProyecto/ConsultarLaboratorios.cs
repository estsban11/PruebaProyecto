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
    public partial class ConsultarLaboratorios : Form
    {
        FormularioServiceBD serviceBD;
        List<Formulario> formularios = new List<Formulario>();
        public ConsultarLaboratorios()
        {
            InitializeComponent();
            serviceBD = new FormularioServiceBD(ExtraerCadena.connectionString);
            LLenarTabla();
        }

        public void LLenarTabla()
        {
            formularios = serviceBD.BuscarFormularioRechazado().Formularios;
            foreach (var item in formularios)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item.IdFormulario;
                dataGridView1.Rows[n].Cells[1].Value = item.FechaPedido;
                dataGridView1.Rows[n].Cells[2].Value = item.FechaLimite;
                dataGridView1.Rows[n].Cells[3].Value = item.Docente.primerNombre;
                dataGridView1.Rows[n].Cells[4].Value = item.NombreAsignatura;
                dataGridView1.Rows[n].Cells[5].Value = item.empleado.PrimerNombre;
                dataGridView1.Rows[n].Cells[6].Value = item.EstadoPedido;
            }
        }
    }
}
