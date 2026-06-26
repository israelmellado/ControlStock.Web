using Microsoft.AspNetCore.Identity.UI.Services;

namespace ControlStock.Web.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // No hace nada (solo desarrollo)
            return Task.CompletedTask;
        }
    }
}
