using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;

namespace DAL
{
   public  class MaterialRepositoryBD
    {

        ConnectionManager connection;
        List<MaterialAdministrador> materiales = new List<MaterialAdministrador>();
        public MaterialRepositoryBD(ConnectionManager Connection)
        {
            connection = Connection; 
        }

        public void GuardarMateriales(MaterialAdministrador material)
        {
            using(var command = connection._connection.CreateCommand())
            {
                command.CommandText = "Registrar_materiales";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("n_material", System.Data.SqlDbType.VarChar).Value = material.NombreProducto;
                command.Parameters.Add("d_material", System.Data.SqlDbType.VarChar).Value = material.DescripcionProducto;
                command.Parameters.Add("can_material", System.Data.SqlDbType.Int).Value = material.CantidadProducto;
                command.ExecuteNonQuery();
            }
        }

        public List<MaterialAdministrador> Consultar()
        {
            materiales.Clear();
            SqlDataReader dataReader;
            using(var command = connection._connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Material";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        if (!dataReader.HasRows) return null;
                        materiales.Add(Mapear(dataReader));
                    }
                    dataReader.Close();
                }
            }
            return materiales;
        }

        private MaterialAdministrador Mapear(SqlDataReader dataReader)
        {
            MaterialAdministrador material = new MaterialAdministrador();
            material.CodigoProducto = ((object)dataReader[@"codigo_producto"]).ToString();
            material.NombreProducto = ((object)dataReader[@"nombre_producto"]).ToString();
            material.DescripcionProducto = ((object)dataReader[@"descripcion_producto"]).ToString();
            material.CantidadProducto  = Convert.ToInt32( ((object)dataReader[@"cantidad_producto"]));
            return material;
        }

        public MaterialAdministrador Buscar(string codigo)
        {
            List<MaterialAdministrador> materiales = Consultar();
            foreach (var item in materiales)
            {
                if(Encontrado(item.CodigoProducto, codigo))
                {
                    return item;
                }
            }
            return null;
        }

        public bool Encontrado(string codigoBuscado, string codigoEncontrado)
        {
            return codigoBuscado == codigoEncontrado;
        }
        public void ActualizarEstadoMaterial(string idPedido, string estado)
        {
            using (var command = connection._connection.CreateCommand())
            {
                command.CommandText = "Actualizar_solicitud_material";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(@"id_material", System.Data.SqlDbType.VarChar).Value = idPedido;
                command.Parameters.Add(@"estado_material", System.Data.SqlDbType.VarChar).Value = estado;
                command.ExecuteNonQuery();
            }
        }
        public MaterialAdministrador BuscarMaterial(string codigo)
        {
            List<MaterialAdministrador> materiales = Consultar();
            return materiales.Where(m=>m.CodigoProducto == codigo || m.NombreProducto.Contains(codigo)).FirstOrDefault();
        }
    }
}
