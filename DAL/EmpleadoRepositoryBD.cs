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
                command.Parameters.Add("Identificacion", System.Data.SqlDbType.VarChar).Value = empleado.Cedula;
                command.Parameters.Add("P_nombre", System.Data.SqlDbType.VarChar).Value = empleado.PrimerNombre;
                command.Parameters.Add("S_nombre", System.Data.SqlDbType.VarChar).Value = empleado.SegundoNombre;
                command.Parameters.Add("P_apellido", System.Data.SqlDbType.VarChar).Value = empleado.PrimerApellido;
                command.Parameters.Add("S_apellido", System.Data.SqlDbType.VarChar).Value = empleado.SegundoApellido;
                command.Parameters.Add("Id_cargo", System.Data.SqlDbType.VarChar).Value = empleado.Cargo.IdCargo;
                command.Parameters.Add("N_cargo", System.Data.SqlDbType.VarChar).Value = empleado.Cargo.NombreCargo;
                command.Parameters.Add("Email", System.Data.SqlDbType.VarChar).Value = empleado.Email;
                command.Parameters.Add("Nombre_usuario", System.Data.SqlDbType.VarChar).Value = empleado.NombreUsuario;
                command.Parameters.Add("Contraseña", System.Data.SqlDbType.VarChar).Value = empleado.Contraseña;
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
    }
}
