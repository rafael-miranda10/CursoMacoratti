using AspnCore_EnviaEmail.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AspnCore_EnviaEmail.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSettings { get; }
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                Execute(email, subject, message).Wait();
                return Task.FromResult(0);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Execute(string email, string subject, string message)
        {
            try
            {
                string toEmail = string.IsNullOrEmpty(email) ? _emailSettings.ToEmail : email;

                // As instâncias da classe MailMessage são usadas para construir 
                // mensagens de e-mail que são transmitidas para um servidor SMTP 
                // para entrega usando a classe SmtpClient
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.UsernameEmail, "Jose Carlos Macoratti")
                };

                // Representa o endereço de um remetente ou destinatário de email
                // Esta classe é usada pelas classes StmpClient e MailMessage
                // para armazenar informações de endereço para mensagens de email
                mail.To.Add(new MailAddress(toEmail));
                mail.CC.Add(new MailAddress(_emailSettings.CcEmail));

                mail.Subject = "Macoratti .net - " + subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                //outras opções
                //mail.Attachments.Add(new Attachment(arquivo));
                //

                using (SmtpClient smtp = new SmtpClient(_emailSettings.Host, _emailSettings.Port))
                {
                    smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
