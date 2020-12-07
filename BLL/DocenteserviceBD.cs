using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.Data.SqlClient;
using Infraestructura;

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
            Email envioEmail = new Email();
            string mensajeEmail = string.Empty;
            try
            {
                connection.Open();
                repository.Guardar(docente);
                envioEmail.EnviarEmailDocente(docente);
                connection.Close();
                return "Se registro correctamente"+ mensajeEmail;

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

      public BuscarDocente ValidarNombreUsuario(string nombreUsuario)
        {
            BuscarDocente respuesta;
            try
            {
                connection.Open();
                Docente docente = repository.BuscarDocente(nombreUsuario);
                
                if (docente != null)
                {
                    respuesta = new BuscarDocente(docente);
                    connection.Close();
                    return respuesta;
                }
                else
                {
                    respuesta = new BuscarDocente("Nombre de usuario invalido");
                    connection.Close();
                    return respuesta;
                }
            }
            catch (Exception e)
            {

                respuesta = new BuscarDocente($"Error: {e.Message}");
                return respuesta;
            }
            finally { connection.Close(); }
        }
        public BuscarDocente ValidarContraseña(string contraseña)
        {
            BuscarDocente respuesta;
            try
            {
                connection.Open();
                Docente docente = repository.BuscarContraseña(contraseña);
                
                if (docente != null)
                {
                    respuesta = new BuscarDocente(docente);
                    connection.Close();
                    return respuesta;
                }
                else
                {
                    respuesta = new BuscarDocente("contraseña invalida");
                    connection.Close();
                    return respuesta;
                }
            }
            catch (Exception e)
            {

                respuesta = new BuscarDocente($"Error: {e.Message}");
                return respuesta;
            }
            finally { connection.Close(); }
        }

        public BuscarDocente BuscarDocente(string identificacion)
        {
            BuscarDocente respuesta;
            try
            {
                connection.Open();
                Docente docente = repository.BuscarDocenteIdentificacion(identificacion);
                if (docente != null)
                {
                    respuesta = new BuscarDocente(docente);
                    connection.Close();
                    return respuesta;
                }
                else
                {
                    respuesta = new BuscarDocente("no se encontro docente");
                    connection.Close();
                    return respuesta;
                }

            }
            catch (Exception e)
            {
                respuesta = new BuscarDocente($"Error: {e.Message}");
                return respuesta;
            }
        }
    }

    public class BuscarDocente
    {
        public Docente Docente { get; set; }
        public string Mensaje { get; set; }
        public bool Encontrado { get; set; }

        public BuscarDocente(Docente docente)
        {
            Docente = docente;
            Encontrado = true;
        }
        public BuscarDocente(string mensaje)
        {
            Mensaje = mensaje;
            Encontrado = false;
        }
    }
}
