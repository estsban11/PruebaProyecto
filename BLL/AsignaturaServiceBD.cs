using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class AsignaturaServiceBD
    {
        private readonly ConnectionManager connection;
        private readonly AsignaturaRepositoryBD repository;

        public AsignaturaServiceBD(string Connection)
        {
            connection = new ConnectionManager(Connection);
            repository = new AsignaturaRepositoryBD(connection); 
        }

        public string Guardar(Asignatura asignatura)
        {
            try
            {
                connection.Open();
                repository.Guardar(asignatura);
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
