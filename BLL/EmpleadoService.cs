using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class EmpleadoService
    {
        EmpleadoRepository repository;

        public EmpleadoService()
        {
            repository = new EmpleadoRepository();
        }

        public string Guardar(Empleado empleado)
        {
            try
            {
                repository.Guardar(empleado);
                return "Se registro correctamente";

            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }
        }

        public ConsultarTodos ConsultarTodos()
        {
            ConsultarTodos respuesta;
            try
            {
                List<Empleado> empleados = repository.Consultar();
                if (empleados != null)
                {
                    respuesta = new ConsultarTodos(empleados);
                    return respuesta;
                }
                else
                {
                    respuesta = new ConsultarTodos("La lista esta vacia");
                    return respuesta;
                }
            }
            catch (Exception e)
            {

                respuesta = new ConsultarTodos($"Error: {e.Message}");
                return respuesta;
            }

        }

    }

    public class ConsultarTodos
    {
        public List<Empleado> Empleados { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultarTodos(List<Empleado> empleados)
        {
            Empleados = empleados;
            Error = false;
        }
        public ConsultarTodos(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
        
    }
}
