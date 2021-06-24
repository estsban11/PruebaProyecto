using System;
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

        public string RegistrarMateriales(MaterialAdministrador material)
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
                List<MaterialAdministrador> materiales = repository.Consultar();
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

        public string Actualizar(string idProducto, string nombreProducto, string descripcionProducto, int cantidadProducto)
        {
            try
            {
                connection.Open();
                repository.Actualizar(idProducto, nombreProducto, descripcionProducto, cantidadProducto);
                connection.Close();
                return "Se actualizo correctamente";
            }
            catch (Exception e)
            {

                return $"Error: {e.Message}";
            }
        }
        public MaterialAdministrador Buscar(string codigo)
        {
            connection.Open();
            MaterialAdministrador material = repository.BuscarMaterial(codigo);
            connection.Close();
            return material;
        }


        public BusquedaMaterial BuscarMaterial(string codigo)
        {
            BusquedaMaterial respuesta;
            try
            {
                connection.Open();
                MaterialAdministrador material = repository.BuscarMaterial(codigo);
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
                connection.Close();
                return respuesta;
            }
            finally
            {
                connection.Close();
            }
        }
        public string ActualizarEstadoMaterial(string idMaterial, string estado)
        {
            try
            {
                connection.Open();
                repository.ActualizarEstadoMaterial(idMaterial, estado);
                connection.Close();
                return "Se actualizo exitosamente";
            }
            catch (Exception e)
            {

                return $"Error: {e.Message}";
            }
        }

        public List<MaterialAdministrador> FiltrarMayorStock()
        {
            List<MaterialAdministrador> materiales;
            connection.Open();
            materiales = repository.FiltrarMayorStock();
            connection.Close();
            return materiales;
        }
        public List<MaterialAdministrador> FiltrarMenorStock()
        {
            List<MaterialAdministrador> materiales;
            connection.Open();
            materiales = repository.FiltrarMenorStock();
            connection.Close();
            return materiales;
        }
    }

   public class RespuestaConsultaMaterial
    {
        public List<MaterialAdministrador> Materiales { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public RespuestaConsultaMaterial(List<MaterialAdministrador> materiales)
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
        public MaterialAdministrador Material { get; set; }
        public bool Error { get; set; }
        public string Mensaje { get; set; }

        public BusquedaMaterial(MaterialAdministrador material)
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
