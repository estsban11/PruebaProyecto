using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class PedidoMonitorServiceBD
    {
        private readonly ConnectionManager connection;
        private readonly PedidoMonitorRepositoryBD repositoryBD;

        public PedidoMonitorServiceBD(string Connection)
        {
            connection = new ConnectionManager(Connection);
            repositoryBD = new PedidoMonitorRepositoryBD(connection);
            
        }

        public string GuardarPedido(PedidoMonitor pedidoMonitor)
        {
            try
            {
                connection.Open();              
                repositoryBD.GuardarTransaccion(pedidoMonitor);
                connection.Close();
                return "Se guardo correctamente";

            }
            catch (Exception e)
            {

                return $"Error: {e.Message}";
            }
        }
    }
}
