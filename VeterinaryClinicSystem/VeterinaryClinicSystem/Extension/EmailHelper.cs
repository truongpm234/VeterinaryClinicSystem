using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinicSystem;

namespace VeterinaryClinicSystem.Extension
{
    public interface IEmailHelper
    {
        Task<bool> SendEmailAsync(string toEmail, string subject, string htmlBody);
    }

    public class EmailHelper : IEmailHelper
    {
        private readonly SmtpSettings _smtp;
        private readonly ILogger<EmailHelper> _logger;

        public EmailHelper(IOptions<SmtpSettings> smtpOptions, ILogger<EmailHelper> logger)
        {
            _smtp = smtpOptions.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string htmlBody)
        {
            if (string.IsNullOrWhiteSpace(toEmail))
            {
                _logger.LogError("Email address is null or empty.");
                return false;
            }

            try
            {
                using var mail = new MailMessage
                {
                    From = new MailAddress(_smtp.User),
                    Subject = subject,
                    Body = htmlBody,
                    IsBodyHtml = true
                };

                mail.To.Add(new MailAddress(toEmail));

                using var client = new SmtpClient(_smtp.Host, _smtp.Port)
                {
                    Credentials = new NetworkCredential(_smtp.User, _smtp.Pass),
                    EnableSsl = _smtp.EnableSsl
                };

                await client.SendMailAsync(mail);
                _logger.LogInformation("Email sent to {Email}", toEmail);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {Email}", toEmail);
                return false;
            }
        }

    }
}