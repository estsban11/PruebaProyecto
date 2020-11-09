using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
using System.Net.Http;

namespace DAL
{
    public class AdministradorRepository
    {
        private string Ruta = @"Empleados.Txt";
        private List<Empleado> empleados;
    

        public AdministradorRepository()
        {
            
        }

        public void Guardar(Empleado administrador)
        {
            FileStream file = new FileStream(Ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"");
            escritor.Close();
            file.Close();

        }

        

    }
}
