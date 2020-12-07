﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;

namespace DAL
{
    public class DocenteRepositoryBD
    {
        ConnectionManager connection;
        List<Docente> docentes = new List<Docente>();
        public DocenteRepositoryBD(ConnectionManager Connection)
        {
            connection = Connection;
        }

        public void Guardar(Docente docente)
        {
            using(var command = connection._connection.CreateCommand())
            {
                command.CommandText = "Registrar_docente";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue ("identificacion",  docente.Identificacion);
                command.Parameters.AddWithValue("p_nombre",  docente.primerNombre);
                command.Parameters.AddWithValue("s_nombre",  docente.segundoNombre);
                command.Parameters.AddWithValue("p_apellido",  docente.primerApellido);
                command.Parameters.AddWithValue("s_apellido",  docente.segundoApellido);
                command.Parameters.AddWithValue("email",  docente.Email);
                command.Parameters.AddWithValue("n_usuario", docente.nombreDeUsuario);
                command.Parameters.AddWithValue("contraseña",  docente.contraseña);
                command.ExecuteNonQuery();
            }
        }

        public List<Docente> Consultar()
        {
            docentes.Clear();
            SqlDataReader sqlDataReader;
            using(var command = connection._connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM docente";
                sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        if (!sqlDataReader.HasRows) return null;
                        docentes.Add(Mapear(sqlDataReader));
                    }
                    sqlDataReader.Close();
                }
            }
            return docentes;
        }

        public Docente Mapear(SqlDataReader dataReader)
        {
            Docente docente = new Docente();
            docente.Identificacion = ((object)dataReader[@"Identificacion"]).ToString();
            docente.primerNombre = ((object)dataReader[@"PrimerNombre"]).ToString();
            docente.segundoNombre =  ((object)dataReader[@"SegundoNombre"]).ToString();
            docente.primerApellido = ((object)dataReader[@"PrimerApellido"]).ToString();
            docente.segundoApellido = ((object)dataReader[@"SegundoApellido"]).ToString();
            docente.nombreDeUsuario = ((object)dataReader[@"NombreUsuario"]).ToString();
            docente.contraseña = ((object)dataReader[@"Contraseña"]).ToString();
            docente.Email = ((object)dataReader[@"Email"]).ToString();
            return docente;
        }

        public Docente BuscarDocente(string nombreUsuario)
        {
            List<Docente> Docentes = Consultar();
            foreach (var item in Docentes)
            {
                if(Encontrado(item.nombreDeUsuario, nombreUsuario))
                {
                    return item;
                }
            }
            return null;
        }

        public Docente BuscarDocenteIdentificacion(string nombreUsuario)
        {
            List<Docente> Docentes = Consultar();
            foreach (var item in Docentes)
            {
                if (Encontrado(item.Identificacion, nombreUsuario))
                {
                    return item;
                }
            }
            return null;
        }
        public Docente BuscarContraseña(string contraseña)
        {
            List<Docente> Docentes = Consultar();
            foreach (var item in Docentes)
            {
                if (Encontrado(item.contraseña, contraseña))
                {
                    return item;
                }
            }
            return null;
        }
        public bool Encontrado(string docenteReg, string docenteBus)
        {
           return docenteReg == docenteBus;
        }

    }
}
