using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class DocenteService
    {
        private DocenteRepository repository;

        public DocenteService()
        {
            repository = new DocenteRepository();
        }
        public string Guardar(Docente docente)
        {
            try
            {
                repository.Guardar(docente);
                return "Se registro correctamente";
            }
            catch ( Exception e)
            {

                return $"Error: {e.Message}";
            }
        }

        public RespuestaConsulta Consultar()
        {
            RespuestaConsulta respuesta;
            try
            {
                List<Docente> docentes = repository.Consultar();
                respuesta = new RespuestaConsulta(docentes);
                respuesta = new RespuestaConsulta("Consulta exitosa");
               
                return respuesta;
            }
            catch (Exception e)
            {

                return respuesta = new RespuestaConsulta($"Error: {e.Message}");
            }
        }
        public RespoConsulta Busqueda(string NombreUsuario)
        {
            RespoConsulta respuesta;
            try
            {
                Docente docente = repository.Buscar(NombreUsuario);
                if (docente != null)
                {
                    respuesta = new RespoConsulta(docente);
                   // respuesta.Encontrado = true;
                    return respuesta;
                }
                else
                {
                    respuesta = new RespoConsulta("No esta registrado");
                   // respuesta.Encontrado = false;
                    return respuesta;
                }
            }
            catch (Exception e)
            {

                respuesta = new RespoConsulta($"Error: {e.Message}");
                return respuesta;
            }
        }

        
    }

    public class RespuestaConsulta
    {
        public List<Docente> Docentes { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public RespuestaConsulta(List<Docente> docentes)
        {
            Docentes = docentes;
            Error = false;
        }
        public RespuestaConsulta(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class RespoConsulta
    {
        public Docente Docente { get; set; }
        public string Mensaje { get; set; }
        public bool Encontrado { get; set; }

        public RespoConsulta(Docente docente)
        {
            Docente = new Docente();
            Docente = docente;
            Encontrado = true;
        }

        public RespoConsulta(string mensaje)
        {
            Mensaje = mensaje;
            Encontrado = false;
        }
    }
}
