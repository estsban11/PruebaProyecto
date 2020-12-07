using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class FormularioServiceBD
    {
        private readonly ConnectionManager connection;
        private readonly FormularioRepositoryBD repository;

        public FormularioServiceBD(string Connection)
        {
            connection = new ConnectionManager(Connection);
            repository = new FormularioRepositoryBD(connection);
        }

        public string GuardarPedido(Formulario formulario)
        {
            try
            {
                connection.Open();
                repository.GuardarTransaction(formulario);
                connection.Close();
                return "Se guardo correctamente";
            }
            catch (Exception e)
            {

                return $"{e.Message}";
            }
            finally { connection.Close(); }
        }

       public FormularioRespuesta BuscarFormulario(string noFormulario)
        {
            FormularioRespuesta respuesta;
            try
            {

                connection.Open();
                Formulario formulario = repository.BuscarFormulario(noFormulario);
                if (formulario != null)
                {
                    respuesta = new FormularioRespuesta(formulario);
                    connection.Close();
                    return respuesta;
                }
                else
                {
                    respuesta = new FormularioRespuesta("No se encontro ningun formulario");
                    connection.Close();
                    return respuesta;
                }
            }
            catch (Exception e)
            {

                respuesta = new FormularioRespuesta($"Error: {e.Message}");
                return respuesta;
            }
            finally { connection.Close(); }
        }

        public List<DetalleFormulario> BuscarMateriales(string noMateriales)
        {
            try
            {
                List<DetalleFormulario> detalleFormularios = new List<DetalleFormulario>();
                connection.Open();
                detalleFormularios = repository.BuscarMateriales(noMateriales);
                connection.Close();
                return detalleFormularios;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public FormularioRespuesta BuscarFormularioPendiente()
        {
            FormularioRespuesta respuesta;
            try
            {
                connection.Open();
                respuesta = new FormularioRespuesta(repository.BuscarformularioPendiente());
                connection.Close();
                return respuesta;

            }
            catch (Exception e)
            {

                respuesta = new FormularioRespuesta($"Error: {e.Message}");
                return respuesta;
            }
        }
        public FormulariosPendientes FormulariosPendientes()
        {
            FormulariosPendientes respuesta;
            try
            {
                connection.Open();
                respuesta = new FormulariosPendientes(repository.ListaFormulariosPendientes());
                connection.Close();
                return respuesta;
            }
            catch (Exception e)
            {

                respuesta = new FormulariosPendientes($"Error: {e.Message}");
                connection.Close();
                return respuesta;
            }
            finally
            {
                connection.Close();
            }
        }
        public ListaFormularios BuscarFormularioRechazado()
        {
            ListaFormularios respuesta;
            try
            {
                connection.Open();
                respuesta = new ListaFormularios(repository.BuscarformularioRechazado());
                connection.Close();
                return respuesta;

            }
            catch (Exception e)
            {
                respuesta = new ListaFormularios($"Error: {e.Message}");
                return respuesta;
            }
        }
        public string ActulizarEstadoFormualrio(string idFormualrio, string estadoPedido)
        {
            try
            {
                connection.Open();
                repository.Actulizar(idFormualrio, estadoPedido);
                connection.Close();
                return $"Se actualizo con exito";
            }
            catch (Exception e)
            {

                return $"Error: {e.Message}";
            }
        }
    }

    public class ListaFormularios
    {
        public List<Formulario> Formularios { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ListaFormularios(List<Formulario> formularios)
        {
            Formularios = formularios;
            Error = false;
        }

        public ListaFormularios(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
    public class FormulariosPendientes
    {
        public List<string> Lista { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public FormulariosPendientes(List<string> lista)
        {
            Lista = lista;
            Error = false;
        }

        public FormulariosPendientes(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
    public class FormularioRespuesta
    {
        public Formulario formulario { get; set; }
        public string Mensaje { get; set; }
        public bool Encontrado { get; set; }

        public FormularioRespuesta(Formulario formulario_)
        {
            formulario = formulario_;
            Encontrado = true;
        }

        public FormularioRespuesta(string mensaje)
        {
            Mensaje = mensaje;
            Encontrado = false;
        }
    }
}
