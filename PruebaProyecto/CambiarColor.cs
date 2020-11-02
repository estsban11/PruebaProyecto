using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaProyecto
{
    public class CambiarColor
    {

        public bool color;

        public void Negro()
        {
            foreach (var form in Application.OpenForms.Cast<Form>())
            {
                form.BackColor = Color.Black;
                form.ForeColor = Color.White;
            }
        }

        public void Blanco()
        {
            foreach (var form in Application.OpenForms.Cast<Form>())
            {
                form.BackColor = Color.White;
                form.ForeColor = Color.Black;
            }

        }

        public void ValidarColorNegro(DialogResult dialogoB)
        {
            if (dialogoB == DialogResult.Yes)
            {
                Negro();
            }
            color = true;

        }

        public void ValidarColorBlanco(DialogResult dialogoN)
        {

            if (dialogoN == DialogResult.Yes)
            {
                Blanco();
            }
            color = false;
        }


    }
}
