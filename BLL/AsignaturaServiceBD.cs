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

        public ListaAsignaturas ListaAsignaturas(string docente)
        {
            ListaAsignaturas lista;
            try
            {
                connection.Open();
                lista = new ListaAsignaturas(repository.ListaAsignaturas(docente));
                connection.Close();
                return lista;
            }
            catch (Exception e)
            {
                lista = new ListaAsignaturas($"Error: {e.Message}");
                return lista;

            }
            finally { connection.Close(); }
        }
        public ListaAsignaturas ListaGruposAsignatura(string nombre)
        {
            ListaAsignaturas lista;
            try
            {
                connection.Open();
                lista = new ListaAsignaturas(repository.ListaGrupos(nombre));
                connection.Close();
                return lista;
            }
            catch (Exception e)
            {
                lista = new ListaAsignaturas($"Error: {e.Message}");
                return lista;

            }
            finally { connection.Close(); }
        }
    }

    public class ListaAsignaturas{
        public List<string> Lista { get; set; }
        public bool Error { get; set; }
        public string Mensaje { get; set; }

        public ListaAsignaturas(List<string> lista)
        {
            Lista = lista;
            Error = false;
        }
        public ListaAsignaturas(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
                
        }
    }
}
