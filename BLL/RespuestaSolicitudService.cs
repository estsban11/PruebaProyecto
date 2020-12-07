using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class RespuestaSolicitudService
    {
        private readonly ConnectionManager connection;
        private readonly RespuestSolicitudRepository solicitudRepository;

        public RespuestaSolicitudService(string conexion)
        {
            connection = new ConnectionManager(conexion);
            solicitudRepository = new RespuestSolicitudRepository(connection);
        }

        public string Guardar(RespuestaSolicitud respuestaSolicitud)
        {
            try
            {
                connection.Open();
                solicitudRepository.Guardar(respuestaSolicitud);
                connection.Close();
                return "Se guardo exitosamente";

            }
            catch (Exception e)
            {

                return $"Error: {e.Message}";
            }
            finally { connection.Close(); }
        }

        public SolicitudRespuesta Buscar(string idPedido)
        {
            SolicitudRespuesta respuesta;
            try
            {
                connection.Open();
                RespuestaSolicitud respuestaSolicitud = solicitudRepository.Buscar(idPedido);
                if (respuestaSolicitud != null)
                {
                    respuesta = new SolicitudRespuesta(respuestaSolicitud);
                    connection.Close();
                    return respuesta;
                }
                else
                {
                    respuesta = new SolicitudRespuesta("No se encontro ninguna solicitud");
                    connection.Close();
                    return respuesta;
                }
            }
            catch (Exception e)
            {

                respuesta = new SolicitudRespuesta($"Erro: {e.Message}");
                return respuesta;
            }
            finally { connection.Close(); }
        }
    }
    public class SolicitudRespuesta
    {
        public RespuestaSolicitud RespuestaSolicitud { get; set; }
        public string Mensaje { get; set; }
        public  bool Encontrado { get; set; }

        public SolicitudRespuesta(RespuestaSolicitud respuesta)
        {
            RespuestaSolicitud = respuesta;
            Encontrado = true;
        }
        public SolicitudRespuesta(string mensaje)
        {
            Mensaje = mensaje;
            Encontrado = false;
        }

    }
}
