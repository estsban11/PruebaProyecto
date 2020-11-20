using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class FormularioServiceBD
    {
        private readonly ConnectionManager connection;
        private readonly FormularioRepositoryBD repository;

        public FormularioServiceBD(string Connection)
        {
            connection = new ConnectionManager(Connection);
            repository = new FormularioRepositoryBD(connection);
        }

        public void GuardarInformacionPedido(Formulario formulario)
        {
            try
            {
                connection.Open();
                repository.GuardarInformacionPedido(formulario);
                connection.Close();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public string GuardarMaterialePedido(Formulario formulario)
        {
            try
            {
                connection.Open();
                repository.GuardarMaterialesPedido(formulario);
                connection.Close();
                return "Se registro correctamente";
            }
            catch (Exception r)
            {
                return $"Error: {r.Message}";
                
            }
        }
    }
}
