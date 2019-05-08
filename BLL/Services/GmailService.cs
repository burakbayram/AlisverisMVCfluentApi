using System.Net;
using System.Net.Mail;

namespace BLL.Services
{
    public class GmailService : IEmailService
    {

        /// <summary>
        /// model dedigimiiz seyker genelde veri tabanına gider
        /// viewmdel de c# içiçnde veritabanına gitmez
        /// </summary>
        public void SendMail(ViewModel.EmailViewModel email)
        {///SMTP mail atıyoruz
            var fromAddress = new MailAddress("info@alisveris.com", "Alisveris.com");
            var toAddress = new MailAddress(email.To);
     
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                ///gercekgmail. v gercek sifre
                Credentials = new NetworkCredential("bburakyildizz11", "istanbulsevgi1")
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject =email.Subject,
                Body = email.Message,
                IsBodyHtml=email.ISHtml
            })
            {
                smtp.Send(message);
            }
        }
    }
}
