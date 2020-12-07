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
                command.Parameters.AddWithValue(@"id_pedido", formulario.IdFormulario);
                command.Parameters.AddWithValue(@"id_docente",  formulario.Docente.Identificacion);
                command.Parameters.AddWithValue(@"id_monitor",  formulario.empleado.Cedula);
                command.Parameters.AddWithValue(@"fecha_pedido", formulario.FechaPedido);
                command.Parameters.AddWithValue(@"fecha_entrega",  formulario.FechaLimite);
                command.Parameters.AddWithValue(@"Estado_pedido", formulario.EstadoPedido);
                command.Parameters.AddWithValue(@"nombre_asignatura",  formulario.NombreAsignatura);
                command.Parameters.AddWithValue(@"grupo_asignatura",  formulario.GrupoAsignatura);
                command.Parameters.AddWithValue(@"hora_asignatura", formulario.HoraAsignatura);
                command.Parameters.AddWithValue(@"nombre_docente",  formulario.Docente.primerNombre);
                command.Parameters.AddWithValue(@"nombre_monitor",  formulario.empleado.PrimerNombre);
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
                    command.Parameters.AddWithValue(@"n_material",  item.NombreMaterial);
                    command.Parameters.AddWithValue(@"descripcion",  item.Descripcion);
                    command.Parameters.AddWithValue(@"cantidad",  item.Cantidad);
                    command.Parameters.AddWithValue(@"estado_producto",  item.Devuelto);
                    command.Parameters.AddWithValue(@"id_pedido",  item.idFormulario);
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

        public void Actulizar(string idFormualrio, string estadoPedido)
        {
            using(var command = connection._connection.CreateCommand())
            {
                command.CommandText = "Actualizar_estado_pedido";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(@"id_pedido", System.Data.SqlDbType.VarChar).Value = idFormualrio;
                command.Parameters.Add(@"estado", System.Data.SqlDbType.VarChar).Value = estadoPedido;
                command.ExecuteNonQuery();

            }
        }

        

        public bool Encontrado(string formularioBuscado, string formularioEncontrado)
        {
            return formularioBuscado == formularioEncontrado;
        }

        public List<string> ListaFormulariosPendientes()
        {
            List<string> lista = new List<string>();
            SqlDataReader sqlDataReader;
            using (var command = connection._connection.CreateCommand())
            {
                command.CommandText = "select * from informacion_pedido where Estado_pedido = 'Pendiente'";
                sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    lista.Add(sqlDataReader[0].ToString());
                }
                sqlDataReader.Close();
            }
            return lista;
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
        public List<Formulario> BuscarformularioRechazado()
        {
            List<Formulario> formularios = ConsultarFormulario();
            return formularios.Where(f => f.EstadoPedido == "Rechazado").ToList();
        }

    }
}
