using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Entity;

namespace Infraestructura
{
    public class Email
    {
        private MailMessage email;
        private SmtpClient smtp;

        public Email()
        {
            smtp = new SmtpClient();
        }

        private void ConfigurarSmtp()
        {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("estsban11@gmail.com", "1004377671");
        }

        public void ConfigurarEmailDocente(Docente docente)
        {
            email = new MailMessage();
            email.To.Add(docente.Email);
            email.From = new MailAddress("estsban11@gmail.com");
            email.Subject = "Registro usuario " 
                +DateTime.Now.ToString("dd/MMM/yyy hh:mm:ss");
            email.Body = $"<b> Hola! {docente.primerNombre} {docente.primerApellido} <b> <br " +
           $" > a sido registrado satisfactoriamnte en the Lab. Su usuario es: {docente.nombreDeUsuario} contraseña: {docente.contraseña}";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
        }

        private void ConfigurarEmailEmpleado(Empleado empleado)
        {
            email = new MailMessage();
            email.To.Add(empleado.Email);
            email.From = new MailAddress("estsban11@gmail.com");
            email.Subject = "Registro usuario "
                + DateTime.Now.ToString("dd/MMM/yyy hh:mm:ss");
            email.Body = $"<b> Hola! {empleado.PrimerNombre} {empleado.PrimerApellido} <b> <br " +
           $" > a sido registrado satisfactoriamnte en the Lab. Su usuario es: {empleado.NombreUsuario} contraseña: {empleado.Contraseña}";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
        }

        public string EnviarEmailDocente(Docente docente)
        {
            try
            {
                ConfigurarSmtp();
                ConfigurarEmailDocente(docente);
                smtp.Send(email);
                return "Correo enviado exitosamente";
            }
            catch (Exception e)
            {

                return $"Error: {e.Message}";
            }
            finally { email.Dispose(); }
        }
        public string EnviarEmailEmpleado(Empleado empleado)
        {
            try
            {
                ConfigurarSmtp();
                ConfigurarEmailEmpleado(empleado);
                smtp.Send(email);
                return "Correo enviado exitosamente";
            }
            catch (Exception e)
            {

                return $"Error: {e.Message}";
            }
            finally { email.Dispose(); }
        }

    }
}
