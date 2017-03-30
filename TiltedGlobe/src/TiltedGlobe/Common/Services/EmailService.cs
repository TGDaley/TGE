using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace TiltedGlobe.Common.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            var msg = new MailMessage {From = new MailAddress("test@surgeforward.com")};

            msg.To.Add(message.Destination);
            msg.IsBodyHtml = true;
            msg.Subject = message.Subject;
            msg.Body = message.Body;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential("test@surgeforward.com", "pass7531")
            };
            await smtp.SendMailAsync(msg);

        }



    }
}