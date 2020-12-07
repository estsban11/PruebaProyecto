using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using Infraestructura;


namespace BLL
{
    public class EmpeladoServiceBD
    {

        private readonly EmpleadoRepositoryBD repositoryBD;
        private readonly ConnectionManager connectionManager;

        public EmpeladoServiceBD(string connection)
        {
            connectionManager = new ConnectionManager(connection);
            repositoryBD = new EmpleadoRepositoryBD(connectionManager);

        }

        public string Guardar(Empleado empleado)
        {
            Email envioEmail = new Email();
            string mensajeEmail = string.Empty;
            try
            {
                connectionManager.Open();
                repositoryBD.Guardar(empleado);
                envioEmail.EnviarEmailEmpleado(empleado);
                connectionManager.Close();
                return $"Se guardo exitoxamente"+ mensajeEmail;
            }
            catch (Exception e)
            {

                return $"Error: {e.Message}";
            }
            finally
            {
                connectionManager.Close();
            }
        }

        public BuscarEmpleado ValidarNombreUsuario(string documento)
        {
            BuscarEmpleado respuesta;
            try
            {
                connectionManager.Open();
                Empleado empleado = repositoryBD.BuscarEmpleado(documento);
                if (empleado != null)
                {
                    respuesta = new BuscarEmpleado(empleado);
                    connectionManager.Close();
                    return respuesta;
                }
                else
                {
                    respuesta = new BuscarEmpleado("No se encontro registrado ese nombre de usuario");
                    connectionManager.Close();
                    return respuesta;
                    
                }
               
               
                
            }
            catch (Exception e)
            {
               
                respuesta = new BuscarEmpleado($"Error: {e.Message}");
                return respuesta;
            }
            finally { connectionManager.Close(); }
        }

        public BuscarEmpleado ValidarContraseña(string contraseña)
        {
            BuscarEmpleado respuesta;
            try
            {
                connectionManager.Open();
                Empleado empleado = repositoryBD.ValidarContraseña(contraseña);
                if(empleado != null)
                {
                    respuesta = new BuscarEmpleado(empleado);
                    connectionManager.Close();
                    return respuesta;
                }
                else
                {
                    respuesta = new BuscarEmpleado("Contraseña incorrecta");
                    connectionManager.Close();
                    return respuesta;
                }
               
            }
            catch (Exception e)
            {

                respuesta = new BuscarEmpleado($"Error: {e.Message}");
                return respuesta;
            }
            finally { connectionManager.Close(); }
        }

        public ListaMonitor ListaNombresMonitor()
        {
            ListaMonitor monitor;
            try
            {
                connectionManager.Open();
                monitor = new ListaMonitor(repositoryBD.ListaNombresMonitor());
                connectionManager.Close();
                return monitor;
            }
            catch (Exception e)
            {

                monitor = new ListaMonitor($"Error: {e.Message}");
                return monitor;
            }
        }

        public string Monitor(string identificacion)
        {
            string iden;
            connectionManager.Open();
            iden = repositoryBD.NombreMonitor(identificacion);
            connectionManager.Close();
            return iden;
        }
        public ListaMonitor ListaMonitores()
        {
            ListaMonitor monitor;
            
            try
            {
                connectionManager.Open();
                monitor = new ListaMonitor(repositoryBD.ListaMonitores());
                connectionManager.Close();
                return monitor;
            }
            catch (Exception e)
            {

                monitor = new ListaMonitor($"Error: {e.Message}");
                return monitor;
            }
        }
        public List<string> LlenarCmbEmpleados()
        {
            List<string> empleados = new List<string>();
            try
            {
                connectionManager.Open();
                empleados = repositoryBD.LlenarCmbEmpleados();
                connectionManager.Close();
                return empleados;
            }
            catch (Exception e)
            {

                throw;
            }
            finally { connectionManager.Close(); }
        }
        public Empleado ValidarCredenciales(string nombreUsuario)
        {
             connectionManager.Open();
             Empleado empleado = repositoryBD.Busqueda(nombreUsuario);
             connectionManager.Close();
            return empleado;
        }


    }
    public class ListaMonitor
    {
        public List<string> lista { get; set; }
        public bool Error { get; set; }
        public string Mensaje { get; set; }

        public ListaMonitor(List<string> Lista)
        {
            lista = Lista;
            Error = false;
        }

        public ListaMonitor(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
        public class BuscarEmpleado
        {
            public Empleado Empleado { get; set; }
            public bool Encontrado { get; set; }
            public string Mensaje { get; set; }

            public BuscarEmpleado(Empleado empleado)
            {
                Empleado = empleado;
                Encontrado = true;
            }
            public BuscarEmpleado(string mensaje)
            {
                Mensaje = mensaje;
                Encontrado = false;
            }
        }
    

}
