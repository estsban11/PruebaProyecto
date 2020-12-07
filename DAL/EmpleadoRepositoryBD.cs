using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;

namespace DAL
{
    public class EmpleadoRepositoryBD
    {

        ConnectionManager connectionManager;
        List<Empleado> empleados = new List<Empleado>();
        public EmpleadoRepositoryBD(ConnectionManager conection)
        {
            connectionManager = conection;
        }

        public void Guardar(Empleado empleado)
        {
            using (var command = connectionManager._connection.CreateCommand())
            {
                command.CommandText = "Guardar";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Identificacion", empleado.Cedula);
                command.Parameters.AddWithValue("P_nombre",  empleado.PrimerNombre);
                command.Parameters.AddWithValue("S_nombre",  empleado.SegundoNombre);
                command.Parameters.AddWithValue("P_apellido", empleado.PrimerApellido);
                command.Parameters.AddWithValue("S_apellido", empleado.SegundoApellido);
                command.Parameters.AddWithValue("Id_cargo",  empleado.Cargo.IdCargo);
                command.Parameters.AddWithValue("N_cargo",  empleado.Cargo.NombreCargo);
                command.Parameters.AddWithValue("Email",  empleado.Email);
                command.Parameters.AddWithValue("Nombre_usuario", empleado.NombreUsuario);
                command.Parameters.AddWithValue("Contraseña",  empleado.Contraseña);
                command.ExecuteNonQuery();
            }
        }

        public List<Empleado> Consulta()
        {
            empleados.Clear();
            SqlDataReader dataReader;
            using (var command = connectionManager._connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Empleado";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        if (!dataReader.HasRows) return null;
                        empleados.Add(Mapear(dataReader));
                    }
                    dataReader.Close();
                }
            }
            return empleados;
        }

        public List<Empleado> ConsultaNombre()
        {
            empleados.Clear();
            SqlDataReader dataReader;
            using (var command = connectionManager._connection.CreateCommand())
            {
                command.CommandText = "SELECT primer_nombre, primer_apellido FROM Empleado Where id_cargo = 002";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        if (!dataReader.HasRows) return null;
                        empleados.Add(Mapear(dataReader));
                    }
                    dataReader.Close();
                }
            }
            return empleados;
        }

        public List<string> ListaMonitores()
        {
            List<string> lista = new List<string>();
            SqlDataReader sqlDataReader;
            using(var command = connectionManager._connection.CreateCommand())
            {
                command.CommandText = "select * from Empleado where id_cargo = 002";
                sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    lista.Add(sqlDataReader[0].ToString());
                }
                sqlDataReader.Close();
            }
            return lista;
        }

        public List<string> ListaNombresMonitor()
        {
            List<string> lista = new List<string>();
            SqlDataReader sqlDataReader;
            using (var command = connectionManager._connection.CreateCommand())
            {
                command.CommandText = "select * from Empleado where id_cargo = 002";
                sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    lista.Add($"{sqlDataReader[1]} {sqlDataReader[3]}");
                }
                sqlDataReader.Close();
            }
            return lista;
        }

        public string NombreMonitor(string identificacion)
        {
            List<Empleado> lista = Consulta();
            string union, primerNombre, primerApellido;
            primerNombre= lista.Where(l => l.Cedula == identificacion).Select(l => l.PrimerNombre).FirstOrDefault();
            primerApellido = lista.Where(l => l.Cedula == identificacion).Select(l => l.PrimerApellido).FirstOrDefault();
            union = $"{primerNombre} {primerApellido}";
            return union;
        }
        
        public Empleado Mapear(SqlDataReader dataReader)
        {
            Empleado empleado = new Empleado();
            empleado.Cedula = ((object)dataReader[@"identificacion"]).ToString();
            empleado.PrimerNombre = ((object)dataReader[@"primer_nombre"]).ToString();
            empleado.SegundoNombre = ((object)dataReader[@"segundo_nombre"]).ToString();
            empleado.PrimerApellido = ((object)dataReader[@"primer_apellido"]).ToString();
            empleado.SegundoApellido = ((object)dataReader[@"segundo_apellido"]).ToString();
            empleado.Email = ((object)dataReader[@"email"]).ToString();
            empleado.NombreUsuario = ((object)dataReader[@"nombre_usuario"]).ToString();
            empleado.Contraseña = ((object)dataReader[@"contraseña"]).ToString();
            empleado.Cargo.IdCargo = ((object)dataReader[@"id_cargo"]).ToString();
            empleado.Cargo.NombreCargo = ((object)dataReader[@"nombre_cargo"]).ToString();
            return empleado;
        }

        public Empleado BuscarEmpleado(string documento)
        {
            List<Empleado> empleados = Consulta();
            foreach (var item in empleados)
            {
                if (Encontrado(item.NombreUsuario, documento))
                {
                    return item;
                }
                    
            }
            return null;
        }
        public Empleado ValidarContraseña(string contraseña)
        {
            List<Empleado> empleados = Consulta();
            foreach (var item in empleados)
            {
                if (Encontrado(item.Contraseña, contraseña))
                {
                    return item;
                }

            }
            return null;
        }

        public bool Encontrado(string documentoRegistrado, string documentoEncontrado)
        {
            return  documentoRegistrado == documentoEncontrado;
        }

       public Empleado Busqueda(string nombreUsuario)
        {
            List<Empleado> empleados = Consulta();
            return empleados.Where(e => e.NombreUsuario == nombreUsuario).FirstOrDefault();
        }

        public List<string> LlenarCmbEmpleados()
        {
            IList<Empleado> empleados = Consulta();
           return  empleados.Where(e => e.Cargo.IdCargo == "002").Select(e=>e.Cedula).ToList();
           
        }
    }
}
