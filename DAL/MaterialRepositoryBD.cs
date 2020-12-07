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
                command.Parameters.AddWithValue("n_material",  material.NombreProducto);
                command.Parameters.AddWithValue("d_material",  material.DescripcionProducto);
                command.Parameters.AddWithValue("can_material",  material.CantidadProducto);
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
                command.Parameters.AddWithValue(@"id_material",idPedido);
                command.Parameters.AddWithValue(@"estado_material",  estado);
                command.ExecuteNonQuery();
            }
        }

        public void Actualizar(string idProducto, string nombreProducto, string descripcionProducto, int cantidadProducto)
        {
            using(var command = connection._connection.CreateCommand())
            {
                command.CommandText = "Actualizar_productos_admin";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue(@"id_producto",  idProducto);
                command.Parameters.AddWithValue(@"nombre",  nombreProducto);
                command.Parameters.AddWithValue(@"descripcion",  descripcionProducto);
                command.Parameters.AddWithValue(@"cantidad",  cantidadProducto);
                command.ExecuteNonQuery();
            }
        }
        public MaterialAdministrador BuscarMaterial(string codigo)
        {
            List<MaterialAdministrador> materiales = Consultar();
            return materiales.Where(m=>m.CodigoProducto == codigo || m.NombreProducto.Equals(codigo,StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        }

        public List<MaterialAdministrador> FiltrarMayorStock()
        {
            List<MaterialAdministrador> materiales = Consultar();
            return materiales.Where(m => m.CantidadProducto >= 15).ToList();
        }

        public List<MaterialAdministrador> FiltrarMenorStock()
        {
            List<MaterialAdministrador> materiales = Consultar();
            return materiales.Where(m => m.CantidadProducto >= 15).ToList();
        }
    }
}
