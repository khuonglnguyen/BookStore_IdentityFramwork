using Microsoft.AspNetCore.Identity.UI.Services;
using System.IO;
using System.Threading.Tasks;

namespace BookStore.IdentityProvider1
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (StreamWriter file = new StreamWriter("register.html"))
            {
                await file.WriteAsync(htmlMessage);
            }
        }
    }
}
