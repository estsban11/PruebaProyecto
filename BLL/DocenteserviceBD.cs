using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.Data.SqlClient;

namespace BLL
{
    public class DocenteserviceBD
    {
        private readonly DocenteRepositoryBD repository;
        private readonly ConnectionManager connection;

        public DocenteserviceBD(string Connection)
        {
            connection = new ConnectionManager(Connection);
            repository = new DocenteRepositoryBD(connection);
        }

        public string Guardar(Docente docente)
        {
            try
            {
                connection.Open();
                repository.Guardar(docente);
                connection.Close();
                return "Se registro correctamente";

            }
            catch (Exception e)
            {

                return $"Error: {e.Message}";
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
