using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;

namespace DAL
{
    public class PedidoMonitorRepositoryBD
    {
        ConnectionManager connection;
        List<MaterialMonitor> materiales = new List<MaterialMonitor>();

        public PedidoMonitorRepositoryBD(ConnectionManager connectionManager)
        {
            connection = connectionManager;
        }

        public void GuardarInformacionPedido(PedidoMonitor pedido, SqlTransaction sqlTransaction)
        {
            using(var command = connection._connection.CreateCommand())
            {
                command.Transaction = sqlTransaction;
                command.CommandText = "Registrar_pedido_monitor";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue(@"id_pedido", pedido.IdPedido);
                command.Parameters.AddWithValue(@"fecha", pedido.Fecha);
                command.Parameters.AddWithValue(@"Descripcion", pedido.Descripcion);
                command.Parameters.AddWithValue(@"ubicacion",  pedido.Ubicacion);
                command.Parameters.AddWithValue(@"subtotal",  pedido.Compra.SubTotal);
                command.Parameters.AddWithValue(@"iva", pedido.Compra.IVA);
                command.Parameters.AddWithValue(@"total", pedido.Compra.Total);
                command.ExecuteNonQuery();
            }
        }

        public void GuardarMaterialesPedido(List<MaterialMonitor> materiales, SqlTransaction sqlTransaction)
        {
            foreach (var item in materiales)
            {
                using(var command = connection._connection.CreateCommand())
                {
                    command.Transaction = sqlTransaction;
                    command.CommandText = "Registrar_materiales_monitor";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"descripcion",  item.DescripcionProducto);
                    command.Parameters.AddWithValue(@"marca", item.MarcaProducto);
                    command.Parameters.AddWithValue(@"cantidad",  item.CantidadProducto);
                    command.Parameters.AddWithValue(@"precio", item.PrecioProducto);
                    command.Parameters.AddWithValue(@"id_pedido", item.IdPedido);
                    command.ExecuteNonQuery();
                }
            }

        }

        public void GuardarTransaccion(PedidoMonitor pedidoMonitor)
        {
            using(SqlTransaction transaction = connection._connection.BeginTransaction())
            {
                GuardarInformacionPedido(pedidoMonitor, transaction);
                GuardarMaterialesPedido(pedidoMonitor.Materiales, transaction);
                transaction.Commit();
            }
        }

    }
}
