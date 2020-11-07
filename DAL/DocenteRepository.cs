using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
using System.ComponentModel;

namespace DAL
{
    public class DocenteRepository
    {
        private string ruta = @"Docentes.txt";

        public void Guardar(Docente docente)
        {
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{docente.nombreDeUsuario};{docente.contraseña};{docente.Identificacion};{docente.primerNombre};{docente.segundoNombre};{docente.primerApellido};{docente.segundoApellido};{docente.nombreCargo}");
            escritor.Close();
            file.Close();
        }

        public List<Docente> Consultar()
        {
            List<Docente> docentes = new List<Docente>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(file);
            string linea = string.Empty;
            while((linea = lector.ReadLine()) != null)
            {
                Docente docente = Mapeo(linea);
                docentes.Add(docente);
            }
            lector.Close();
            file.Close();
            return docentes;

        }

        private Docente Mapeo(string linea)
        {
            Docente docente = new Docente();
            char delimiter = ';';
            string[] matriz = linea.Split(delimiter);
            docente.nombreDeUsuario = matriz[0];
            docente.contraseña = matriz[1];
            docente.primerNombre = matriz[2];
            docente.segundoNombre = matriz[3];
            docente.primerApellido = matriz[4];
            docente.segundoApellido = matriz[5];
            docente.Identificacion = matriz[6];
            return docente;
        }

        public Docente Buscar(string nombreUsuario)
        {
            List<Docente> docentes = Consultar();
            foreach (var item in docentes)
            {
                if (EsEncontrado(item.nombreDeUsuario, nombreUsuario))
                {
                    return item;
                }
            }
            return null;
        }
        private bool EsEncontrado(string nombreUsuarioReg, string nombreUsuarioBus)
        {
            return nombreUsuarioReg == nombreUsuarioBus;
        }
    }
}
