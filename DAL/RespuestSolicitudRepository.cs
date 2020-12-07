using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{
    public class RespuestSolicitudRepository
    {
        ConnectionManager connection;
        List<RespuestaSolicitud> respuestaSolicituds = new List<RespuestaSolicitud>();

        public RespuestSolicitudRepository(ConnectionManager connectionManager)
        {
            connection = connectionManager;
        }

        public void Guardar(RespuestaSolicitud respuestaSolicitud)
        {
            using(var command = connection._connection.CreateCommand())
            {
                command.CommandText = "Registrar_Respuesta_solicitud";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue(@"nombre", respuestaSolicitud.Nombre);
                command.Parameters.AddWithValue(@"descripcion", respuestaSolicitud.Descripcion);
                command.Parameters.AddWithValue(@"estado", respuestaSolicitud.Estado);
                command.Parameters.AddWithValue(@"cantidad", respuestaSolicitud.Cantidad);
                command.Parameters.AddWithValue(@"id_pedido", respuestaSolicitud.IdSolicitud);
                command.ExecuteNonQuery();
            }
        }

        public List<RespuestaSolicitud> Consultar()
        {
            respuestaSolicituds.Clear();
            SqlDataReader dataReader;
            using (var command = connection._connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Respuesta_solicitud ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        if (!dataReader.HasRows) return null;
                        respuestaSolicituds.Add(Mapear(dataReader));
                    }
                    dataReader.Close();
                }
            }
            return respuestaSolicituds;
        }

        public RespuestaSolicitud Mapear(SqlDataReader sqlDataReader)
        {
            RespuestaSolicitud respuestaSolicitud = new RespuestaSolicitud();
            respuestaSolicitud.IdFormulario = ((object)sqlDataReader[@"IdFormulario"]).ToString();
            respuestaSolicitud.Nombre = ((object)sqlDataReader[@"nombre"]).ToString();
            respuestaSolicitud.Descripcion = ((object)sqlDataReader[@"Descripcion"]).ToString();
           respuestaSolicitud.Estado =  ((object)sqlDataReader[@"estado"]).ToString();
            respuestaSolicitud.Cantidad = Convert.ToInt32(((object)sqlDataReader[@"Cantidad"]));
            respuestaSolicitud.IdSolicitud = ((object)sqlDataReader[@"IdPedido"]).ToString();
            return respuestaSolicitud;
        }

        public RespuestaSolicitud Buscar(string idPedido)
        {
            List<RespuestaSolicitud> materiales = Consultar();
            foreach (var item in materiales)
            {
                if (Encontrado(item.IdSolicitud, idPedido))
                {
                    return item;
                }
            }
            return null;
        }
        public bool Encontrado(string idBuscado, string idEncontrado)
        {
            return idBuscado == idEncontrado;
        }
    }
}
