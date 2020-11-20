﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
   public class MaterialServiceBD
    {
        private readonly ConnectionManager connection;
        private readonly MaterialRepositoryBD repository;

        public MaterialServiceBD(string Connection)
        {
            connection = new ConnectionManager(Connection);
            repository = new MaterialRepositoryBD(connection);
        }

        public string RegistrarMateriales(Material material)
        {
            try
            {
                connection.Open();
                repository.GuardarMateriales(material);
                connection.Close();
                return "Se registro correctamente";
            }
            catch (Exception e)
            {

                return $"Error: {e.Message}";
            }
            finally { connection.Close(); }
        }

        public RespuestaConsultaMaterial Consulta()
        {
            RespuestaConsultaMaterial respuesta;
            try
            {
                
                connection.Open();
                List<Material> materiales = repository.Consultar();
                respuesta = new RespuestaConsultaMaterial(materiales);
                connection.Close();
                return respuesta;
            }
            catch (Exception e)
            {

                respuesta = new RespuestaConsultaMaterial($"Error: {e.Message}");
                return respuesta;
            }
            finally { connection.Close(); }
        }

        public Material Buscar(string codigo)
        {
            connection.Open();
            Material material = repository.BuscarMaterial(codigo);
            connection.Close();
            return material;
        }


        public BusquedaMaterial BuscarMaterial(string codigo)
        {
            BusquedaMaterial respuesta;
            try
            {
                connection.Open();
                Material material = repository.Buscar(codigo);
                if(material!= null)
                {
                    respuesta = new BusquedaMaterial(material);
                    connection.Close();
                    return respuesta;
                    
                }
                else
                {
                    respuesta = new BusquedaMaterial("No esta registrado");
                    return respuesta;
                }
            }
            catch (Exception e)
            { 

            respuesta = new BusquedaMaterial($"Error: {e.Message}");
                return respuesta;
            }
            finally
            {
                connection.Close();
            }
        }
    }

   public class RespuestaConsultaMaterial
    {
        public List<Material> Materiales { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public RespuestaConsultaMaterial(List<Material> materiales)
        {
            Materiales = materiales;
            Error = false;
        }

        public RespuestaConsultaMaterial(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class BusquedaMaterial
    {
        public Material Material { get; set; }
        public bool Error { get; set; }
        public string Mensaje { get; set; }

        public BusquedaMaterial(Material material)
        {
            Material = material;
            Error = true;
        }
        public BusquedaMaterial(string mensaje)
        {
            Mensaje = mensaje;
            Error = false;
        }
    }
}