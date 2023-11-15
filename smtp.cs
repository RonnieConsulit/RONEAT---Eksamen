using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RONEAT
{
    public class Email
    {
        private const string SmtpServer = " smtp.gmail.com";
        private const int SmtpPort = 587;
        private const string SmtpUsername = "no.reply.roneat@gmail.com";
        private const string SmtpPassword = "tykv ttfy ynto qrrp"; 
            
            //!!roneatforthewin23

        public void SendEmail(string to, string subject, string body)
        {
            using (var client = new SmtpClient(SmtpServer, SmtpPort))
            {
                client.EnableSsl = true; // Aktiver SSL
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(SmtpUsername, SmtpPassword);

                var message = new MailMessage
                {
                    From = new MailAddress(SmtpUsername),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };

                message.To.Add(to);

                try
                {
                    client.Send(message);
                    Console.WriteLine();
                    Console.WriteLine("E-mail sendt succesfuldt.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fejl ved afsendelse af e-mail: {ex.Message}");
                }
            }
        }
    }
}