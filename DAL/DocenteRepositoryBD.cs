using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;

namespace DAL
{
    public class DocenteRepositoryBD
    {
        ConnectionManager connection;
        public DocenteRepositoryBD(ConnectionManager Connection)
        {
            connection = Connection;
        }

        public void Guardar(Docente docente)
        {
            using(var command = connection._connection.CreateCommand())
            {
                command.CommandText = "Registrar_docente";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("identificacion", System.Data.SqlDbType.VarChar).Value = docente.Identificacion;
                command.Parameters.Add("p_nombre", System.Data.SqlDbType.VarChar).Value = docente.primerNombre;
                command.Parameters.Add("s_nombre", System.Data.SqlDbType.VarChar).Value = docente.segundoNombre;
                command.Parameters.Add("p_apellido", System.Data.SqlDbType.VarChar).Value = docente.primerApellido;
                command.Parameters.Add("s_apellido", System.Data.SqlDbType.VarChar).Value = docente.segundoApellido;
                command.Parameters.Add("email", System.Data.SqlDbType.VarChar).Value = docente.Email;
                command.Parameters.Add("n_usuario", System.Data.SqlDbType.VarChar).Value = docente.nombreDeUsuario;
                command.Parameters.Add("contraseña", System.Data.SqlDbType.VarChar).Value = docente.contraseña;
                command.ExecuteNonQuery();
            }
        }




    }
}
