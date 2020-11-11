using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class AdministradorService
    {
        AdministradorRepository repository;

        public AdministradorService()
        {
            repository = new AdministradorRepository();
        }

        public string Guardar(Administrador administrador)
        {
            try
            {
                repository.Guardar(administrador);
                return "Se registro correctamente";

            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }
        }

    }
}
