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
    public class EmpleadoRepository
    {
        private string Ruta = @"Empleados.Txt";
        private List<Empleado> empleados;
    

        public EmpleadoRepository()
        {
            
        }

        public void Guardar(Empleado empleado)
        {
            FileStream file = new FileStream(Ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{empleado.Cedula};{empleado.PrimerNombre};{empleado.SegundoNombre};{empleado.PrimerApellido};{empleado.SegundoApellido};" +
                $"{empleado.Cargo};{empleado.NombreUsuario};{empleado.Contraseña}");
            escritor.Close();
            file.Close();
        }

        public List<Empleado> Consultar()
        {
            List<Empleado> empleados = new List<Empleado>();
            FileStream file = new FileStream(Ruta,  FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(file);
            string liena = string.Empty;
            while((liena = lector.ReadLine())!= null)
            {
                Empleado empleado = Mapear(liena);
                empleados.Add(empleado);

            }
            lector.Close();
            file.Close();
            return empleados;
        }
        
        public Empleado Mapear(string linea)
        {
            Empleado empleado = new Empleado();
            char delimitador = ';';
            string[] registro = linea.Split(delimitador);
            empleado.Cedula = registro[0];
            empleado.PrimerNombre = registro[1];
            empleado.SegundoNombre = registro[2];
            empleado.PrimerApellido = registro[3];
            empleado.SegundoApellido = registro[4];
            empleado.Cargo.NombreCargo = registro[5];
            empleado.NombreUsuario = registro[6];
            empleado.Contraseña = registro[7];
            return empleado
;        }
    }
}
