﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;
namespace DAL
{
   public  class AsignaturaRepositoryBD
    {

        ConnectionManager connection;

        public AsignaturaRepositoryBD(ConnectionManager Connection)
        {
            connection = Connection; 
        }

        public void Guardar(Asignatura asignatura)
        {
            using(var command = connection._connection.CreateCommand())
            {
                command.CommandText = "Registrar_asignatura";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("c_asignatura", System.Data.SqlDbType.VarChar).Value = asignatura.CodigoMateria;
                command.Parameters.Add("n_asignatura", System.Data.SqlDbType.VarChar).Value = asignatura.NombreMateria;
                command.Parameters.Add("n_grupo", System.Data.SqlDbType.VarChar).Value = asignatura.NumeroGrupo;
                command.Parameters.Add("h_laboratorio", System.Data.SqlDbType.VarChar).Value = asignatura.HorasLaboratorio;
                command.Parameters.Add("id_docente", System.Data.SqlDbType.VarChar).Value = asignatura.Docente.Identificacion;
                command.ExecuteNonQuery();
            }
        }

        public List<string> ListaAsignaturas(string docente)
        {
            List<string> lista = new List<string>();
            SqlDataReader sqlDataReader;
            using (var command = connection._connection.CreateCommand())
            {
                command.CommandText = $"select * from asignatura where id_docente = {docente}";
                sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    lista.Add(sqlDataReader[1].ToString());
                }
                sqlDataReader.Close();
            }
            return lista;
        }

        public List<string> ListaGrupos(string nombre)
        {
            List<string> lista = new List<string>();
            SqlDataReader sqlDataReader;
            using (var command = connection._connection.CreateCommand())
            {
                command.CommandText = $"select * from asignatura where Nombre_materia = {nombre}";
                sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    lista.Add(sqlDataReader[2].ToString());
                }
                sqlDataReader.Close();
            }
            return lista;
        }


        }
        
    }

