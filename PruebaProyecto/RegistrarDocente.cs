using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaProyecto
{
    public partial class RegistrarDocente : Form
    {
        public RegistrarDocente()
        {
            InitializeComponent();
        }

        private void btRegistrarAsignatura_Click(object sender, EventArgs e)
        {
            RegistrarAsignatura registrarAsignatura = new RegistrarAsignatura();
            registrarAsignatura.Opacity = 0.70;
            registrarAsignatura.Show();
        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se registro correctamente", "Registro", MessageBoxButtons.OK);
        }
    }
}
