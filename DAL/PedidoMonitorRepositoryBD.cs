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
                command.Parameters.Add(@"id_pedido", System.Data.SqlDbType.VarChar).Value = pedido.IdPedido;
                command.Parameters.Add(@"fecha", System.Data.SqlDbType.DateTime).Value = pedido.Fecha;
                command.Parameters.Add(@"Descripcion", System.Data.SqlDbType.VarChar).Value = pedido.Descripcion;
                command.Parameters.Add(@"ubicacion", System.Data.SqlDbType.VarChar).Value = pedido.Ubicacion;
                command.Parameters.Add(@"subtotal", System.Data.SqlDbType.Float).Value = pedido.Compra.SubTotal;
                command.Parameters.Add(@"iva", System.Data.SqlDbType.Float).Value = pedido.Compra.IVA;
                command.Parameters.Add(@"total", System.Data.SqlDbType.Float).Value = pedido.Compra.Total;
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
                    command.Parameters.Add(@"descripcion", System.Data.SqlDbType.VarChar).Value = item.DescripcionProducto;
                    command.Parameters.Add(@"marca", System.Data.SqlDbType.VarChar).Value = item.MarcaProducto;
                    command.Parameters.Add(@"cantidad", System.Data.SqlDbType.Int).Value = item.CantidadProducto;
                    command.Parameters.Add(@"precio", System.Data.SqlDbType.Float).Value = item.PrecioProducto;
                    command.Parameters.Add(@"id_pedido", System.Data.SqlDbType.VarChar).Value = item.IdPedido;
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
