using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirrorArbProv.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message, string namn, string telefon, string company);
    }
}
