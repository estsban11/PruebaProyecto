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
        List<Material> materiales = new List<Material>();
        public MaterialRepositoryBD(ConnectionManager Connection)
        {
            connection = Connection; 
        }

        public void GuardarMateriales(Material material)
        {
            using(var command = connection._connection.CreateCommand())
            {
                command.CommandText = "Registrar_materiales";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("c_material", System.Data.SqlDbType.VarChar).Value = material.CodigoProducto;
                command.Parameters.Add("n_material", System.Data.SqlDbType.VarChar).Value = material.NombreProducto;
                command.Parameters.Add("d_material", System.Data.SqlDbType.VarChar).Value = material.DescripcionProducto;
                command.Parameters.Add("can_material", System.Data.SqlDbType.Int).Value = material.CantidadProducto;
                command.Parameters.Add("p_material", System.Data.SqlDbType.Float).Value = material.PrecioProducto;
                command.ExecuteNonQuery();
            }
        }

        public List<Material> Consultar()
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

        private Material Mapear(SqlDataReader dataReader)
        {
            Material material = new Material();
            material.CodigoProducto = ((object)dataReader[@"codigo_producto"]).ToString();
            material.NombreProducto = ((object)dataReader[@"nombre_producto"]).ToString();
            material.DescripcionProducto = ((object)dataReader[@"descripcion_producto"]).ToString();
            material.CantidadProducto  = Convert.ToInt32( ((object)dataReader[@"cantidad_producto"]));
            material.PrecioProducto = Convert.ToDouble(((object)dataReader[@"precio_producto"]));
            return material;
        }

        public Material Buscar(string codigo)
        {
            List<Material> materiales = Consultar();
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
        public Material BuscarMaterial(string codigo)
        {
            List<Material> materiales = Consultar();
            return materiales.Where(m=>m.CodigoProducto == codigo || m.NombreProducto == codigo).FirstOrDefault();
        }
    }
}
