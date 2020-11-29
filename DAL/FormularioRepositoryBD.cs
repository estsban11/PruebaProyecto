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
        List<Formulario> formularios = new List<Formulario>();
        List<DetalleFormulario> detalleFormularios = new List<DetalleFormulario>();

        public FormularioRepositoryBD(ConnectionManager Connection)
        {
            connection = Connection;
        }

        public void GuardarInformacionPedido(Formulario formulario, SqlTransaction transaction)
        {
            using(var command = connection._connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = "RegistrarPedido";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(@"id_pedido", System.Data.SqlDbType.VarChar).Value = formulario.IdFormulario;
                command.Parameters.Add(@"id_docente", System.Data.SqlDbType.VarChar).Value = formulario.Docente.Identificacion;
                command.Parameters.Add(@"id_monitor", System.Data.SqlDbType.VarChar).Value = formulario.empleado.Cedula;
                command.Parameters.Add(@"fecha_pedido", System.Data.SqlDbType.DateTime).Value = formulario.FechaPedido;
                command.Parameters.Add(@"fecha_entrega", System.Data.SqlDbType.DateTime).Value = formulario.FechaLimite;
                command.Parameters.Add(@"Estado_pedido", System.Data.SqlDbType.VarChar).Value = formulario.EstadoPedido;
                command.Parameters.Add(@"nombre_asignatura", System.Data.SqlDbType.VarChar).Value = formulario.NombreAsignatura;
                command.Parameters.Add(@"grupo_asignatura", System.Data.SqlDbType.VarChar).Value = formulario.GrupoAsignatura;
                command.Parameters.Add(@"hora_asignatura", System.Data.SqlDbType.VarChar).Value = formulario.HoraAsignatura;
                command.Parameters.Add(@"nombre_docente", System.Data.SqlDbType.VarChar).Value = formulario.Docente.primerNombre;
                command.Parameters.Add(@"nombre_monitor", System.Data.SqlDbType.VarChar).Value = formulario.empleado.PrimerNombre;
                command.ExecuteNonQuery();
            }
        }

        public void GuardarMaterialesPedido(List<DetalleFormulario> detalles, SqlTransaction transaction)
        {
            foreach (var item in detalles)
            {
                using (var command = connection._connection.CreateCommand())
                {

                    command.Transaction = transaction;
                    command.CommandText = "Registrar_materiales_pedido";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(@"n_material", System.Data.SqlDbType.VarChar).Value = item.NombreMaterial;
                    command.Parameters.Add(@"descripcion", System.Data.SqlDbType.VarChar).Value = item.Descripcion;
                    command.Parameters.Add(@"cantidad", System.Data.SqlDbType.Int).Value = item.Cantidad;
                    command.Parameters.Add(@"estado_producto", System.Data.SqlDbType.VarChar).Value = item.Devuelto;
                    command.Parameters.Add(@"id_pedido", System.Data.SqlDbType.VarChar).Value = item.idFormulario;
                    command.ExecuteNonQuery();
                }
            }

            }

        public void GuardarTransaction(Formulario formulario)
        {
            using(SqlTransaction transaction = connection._connection.BeginTransaction())
            {
                GuardarInformacionPedido(formulario, transaction);
                GuardarMaterialesPedido(formulario.detalleFormulario, transaction);
                transaction.Commit();
            }
        }


        public List<Formulario> ConsultarFormulario()
        {
            formularios.Clear();
            SqlDataReader sqlDataReader;
            using(var command = connection._connection.CreateCommand())
            {
                command.CommandText = "Select * from informacion_pedido";
                sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        if (!sqlDataReader.HasRows) return null;
                        formularios.Add(Mapear(sqlDataReader));
                    }
                    sqlDataReader.Close();
                }
            }
            return formularios;
        }

        public Formulario Mapear(SqlDataReader sqlDataReader)
        {
            Formulario formulario = new Formulario();
            formulario.IdFormulario = ((object)sqlDataReader[@"id_pedido"]).ToString();
            formulario.Docente.Identificacion = ((object)sqlDataReader[@"id_docente"]).ToString();
            formulario.empleado.Cedula = ((object)sqlDataReader[@"id_monitor"]).ToString();
            formulario.FechaPedido = Convert.ToDateTime(((object)sqlDataReader[@"fecha_pedido"]));
            formulario.FechaLimite = Convert.ToDateTime(((object)sqlDataReader[@"fecha_entrega"]));
            formulario.EstadoPedido = ((object)sqlDataReader[@"estado_pedido"]).ToString();
            formulario.NombreAsignatura = ((object)sqlDataReader[@"nombre_asignatura"]).ToString();
            formulario.GrupoAsignatura = ((object)sqlDataReader[@"grupo_asignatura"]).ToString();
            formulario.HoraAsignatura = ((object)sqlDataReader[@"hora_asignatura"]).ToString();
            formulario.Docente.primerNombre = ((object)sqlDataReader[@"nombre_docente"]).ToString();
            formulario.empleado.PrimerNombre = ((object)sqlDataReader[@"nombre_monitor"]).ToString();
            return formulario;
        }

        public List<DetalleFormulario> ConsultarMateriales()
        {
            detalleFormularios.Clear();
            SqlDataReader sqlDataReader;
            using(var command = connection._connection.CreateCommand())
            {
                command.CommandText = "select * from pedido_materiales";
                sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        if (!sqlDataReader.HasRows) return null;
                        detalleFormularios.Add(MapearMateriales(sqlDataReader));
                    }
                    sqlDataReader.Close();
                }
            }
            return detalleFormularios;
        }
        

        public DetalleFormulario MapearMateriales(SqlDataReader sqlDataReader)
        {
            DetalleFormulario detalleFormulario = new DetalleFormulario();
            detalleFormulario.idProducto = ((object)sqlDataReader[@"id_material"]).ToString();
            detalleFormulario.NombreMaterial  = ((object)sqlDataReader[@"nombre_material"]).ToString();
            detalleFormulario.Descripcion = ((object)sqlDataReader[@"descripcion"]).ToString();
            detalleFormulario.Cantidad = Convert.ToInt32( ((object)sqlDataReader[@"cantidad"]));
            detalleFormulario.Devuelto = ((object)sqlDataReader[@"estado"]).ToString();
            detalleFormulario.idFormulario = ((object)sqlDataReader[@"id_pedido"]).ToString();
            return detalleFormulario;
        }

        public Formulario BuscarFormulario(string noFormulario)
        {
            List<Formulario> formularios = ConsultarFormulario();
            foreach (var item in formularios)
            {
                if(Encontrado(item.IdFormulario, noFormulario))
                {
                    return item;
                }
            }
            return null;
        }


        

        public bool Encontrado(string formularioBuscado, string formularioEncontrado)
        {
            return formularioBuscado == formularioEncontrado;
        }

        public Formulario BuscarformularioPendiente()
        {
            List<Formulario> formularios = ConsultarFormulario();
           return formularios.Where(f => f.EstadoPedido == "Pendiente").FirstOrDefault();
        }
        public List<DetalleFormulario> BuscarMateriales(string noFormulario)
        {
            List<DetalleFormulario> detalleFormularios = ConsultarMateriales();
            return detalleFormularios.Where(d => d.idFormulario == noFormulario).ToList();
        }
        
    }
}
