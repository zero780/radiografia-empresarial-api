using Microsoft.Exchange.WebServices.Data;
using RadiografiaEmpresarial.Core.DTOs;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RadiografiaEmpresarial.Core.Email
{
    public class SendMail : ISendMail
    {
        private string senderMail;
        private string smtp;
        private int port;
        private string password;
        private bool useSsl;
        private bool useCredentials;

        public SendMail()
        {
            //office 365
            /*senderMail = "testradiografiaempresarial@outlook.com";
            smtp = "SMTP.Office365.com";
            port = 587;
            password = "W?8k!3$z";
            useSsl = true;
            useCredentials = false;*/

            //gmail
            senderMail = "testradiografiaempresarial@gmail.com";
            smtp = "smtp.gmail.com";
            port = 587;
            password = "W?8k!3$z";
            useSsl = true;
            useCredentials = false;
        }

        private static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            
            bool result = false;
            Uri redirectionUri = new Uri(redirectionUrl);
            
            if (redirectionUri.Scheme == "https")
            {
                result = true;
            }
            return result;
        }

        //para office 365
        public bool Send(string subject, string body, string correo)
        {
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2015);
            service.Credentials = new WebCredentials(senderMail, password, smtp);
            service.TraceEnabled = true;
            service.TraceFlags = TraceFlags.All;
            service.AutodiscoverUrl(senderMail, RedirectionUrlValidationCallback);

            EmailMessage email = new EmailMessage(service);
            email.ToRecipients.Add(correo);//Poner User.Email
            email.Subject = subject;
            email.Body = new MessageBody(body);

            try
            {
                email.Send();
                return true;
            }
            catch (SmtpFailedRecipientsException ex)
            {
                for (int i = 0; i < ex.InnerExceptions.Length; i++)
                {
                    SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy ||
                        status == SmtpStatusCode.MailboxUnavailable)
                    {
                        Console.WriteLine("Delivery failed - retrying in 5 seconds.");
                        System.Threading.Thread.Sleep(5000);
                        email.Send();
                    }
                    else
                    {
                        Console.WriteLine("Failed to deliver message to {0}",
                            ex.InnerExceptions[i].FailedRecipient);
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in RetryIfBusy(): {0}",
                        ex.ToString());
                return false;
            }
        }

        //para gmail
        public bool SendGmail(string subject, string body, string correo)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

            mail.IsBodyHtml = true;
            mail.From = new MailAddress(senderMail, "Radiografía Empresarial ESPOL");
            mail.Subject = subject;
            mail.Body = new MessageBody(body);
            mail.To.Add(correo);
            
            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = smtp;
            smtpClient.Port = port;
            smtpClient.Credentials = new NetworkCredential(senderMail, password);
            smtpClient.EnableSsl = useSsl;
            try
            {
                smtpClient.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in RetryIfBusy(): {0}",
                        ex.ToString());
                return false;
            }
        }

        public bool WelcomeMail(AuthUsuarios user)
        {

            string _subject = "Bienvenido " + user.Nombre;
            string _body = "<h1> Bienvenido al Portal de Radiografia Empresarial </h1>" +
                "<p> Su usario ha sido creado en el sistema, acceder con su cuenta de ESPOL al enlace: <a href=\"https://200.10.147.98\"> www.radiografiaempresarial.espol.edu.ec </a></p>"; //colocar url en produccion

            return SendGmail(_subject, _body, user.Email);
        }

        public bool WelcomeToGroupMail(AuthUsuarios user)
        {

            string _subject = "Nuevo Grupo de Trabajo ";
            string _body = "<h1> Bienvenido al Portal de Radiografia Empresarial </h1>" +
                "<p> Su usario " + user.Nombre + " ha sido agregado a un grupo de trabajo, para mayor información acceder con su cuenta de ESPOL al enlace: <a href=\"https://200.10.147.98\"> www.radiografiaempresarial.espol.edu.ec </a></p>"; //colocar url en produccion

            return SendGmail(_subject, _body, user.Email);
        }

        public bool ResponseRadMail(AuthUsuarios user, CoreGrupos grupos)
        {
            string _subject = "Llenado de Información";
            string _body = "<h1>Información Ingresada en la Radiografía</h1>" + "<p> El " + user.Nombre + " ingreso información de la Empresa " + grupos.IdOrganizacionNavigation.Nombre + "</p>";

            return SendGmail(_subject, _body, grupos.IdSupervisadorNavigation.Email);
        }


    }
}
