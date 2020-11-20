using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;

namespace DAL
{
    public class FormularioRepositoryBD
    {
        ConnectionManager connection;

        public FormularioRepositoryBD(ConnectionManager Connection)
        {
            connection = Connection;
        }

        public void GuardarInformacionPedido(Formulario formulario)
        {
            using(var command = connection._connection.CreateCommand())
            {
                command.CommandText = "RegistrarPedido";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(@"id_pedido", System.Data.SqlDbType.VarChar).Value = formulario.IdFormulario;
                command.Parameters.Add(@"id_docente", System.Data.SqlDbType.VarChar).Value = formulario.Docente.Identificacion;
                command.Parameters.Add(@"id_monitor", System.Data.SqlDbType.VarChar).Value = formulario.empleado.Cedula;
                command.Parameters.Add(@"fecha_pedido", System.Data.SqlDbType.DateTime).Value = formulario.FechaPedido;
                command.Parameters.Add(@"fecha_entrega", System.Data.SqlDbType.DateTime).Value = formulario.FechaLimite;
                command.ExecuteNonQuery();
            }
        }

        public void GuardarMaterialesPedido(Formulario formulario)
        {
            using (var command = connection._connection.CreateCommand())
            {
                command.CommandText = "Registrar_materiales_pedido";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(@"id_m", System.Data.SqlDbType.VarChar).Value = formulario.Material.CodigoProducto;
                command.Parameters.Add(@"n_material", System.Data.SqlDbType.VarChar).Value = formulario.Material.NombreProducto;
                command.Parameters.Add(@"descripcion", System.Data.SqlDbType.VarChar).Value = formulario.Material.DescripcionProducto;
                command.Parameters.Add(@"cantidad", System.Data.SqlDbType.Int).Value = formulario.Material.CantidadProducto;
                command.Parameters.Add(@"id_pedido", System.Data.SqlDbType.VarChar).Value = formulario.IdFormulario;
            }
            }
    }
}
