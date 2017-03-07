using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace MirrorArbProv.Services
{
    public class EmailService : IEmailSender
    {
        public async Task SendEmailAsync(string email, string title, string message, string namn, string telefon, string company)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(email, "Kund"),
                Subject = title,
                PlainTextContent = message,
                HtmlContent = "<br><br>" + "<strong>Namn: </strong>" + namn + "<br><strong>E-post: </strong>" + email + "<br><strong>Telefon: </strong>" + telefon + "<br><strong>Företag: </strong>" + company + "<br><br><strong>Meddelande: </strong>" + message
            };
            msg.AddTo(new EmailAddress("mirrorarbprov@gmail.com", "Support"));
            var response = await client.SendEmailAsync(msg);
        }
    }
}
