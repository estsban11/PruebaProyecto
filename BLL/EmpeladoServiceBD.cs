using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;


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
            try
            {
                connectionManager.Open();
                repositoryBD.Guardar(empleado);
                connectionManager.Close();
                return "Se guardo exitoxamente";
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
                respuesta = new BuscarEmpleado(empleado);
                connectionManager.Close();
                return respuesta;
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
                respuesta = new BuscarEmpleado(empleado);
                connectionManager.Close();
                return respuesta;
            }
            catch (Exception e)
            {

                respuesta = new BuscarEmpleado($"Error: {e.Message}");
                return respuesta;
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
