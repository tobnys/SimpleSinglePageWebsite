using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirrorArbProv.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using MirrorArbProv.Models;
using System.IO;

namespace MirrorArbProv.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEmailSender _emailSender;

        public HomeController(IEmailSender emailSender)
        {
            _emailSender = emailSender; 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> sendMail(EmailOptions emailOptions)
        {
            if(ModelState.IsValid)
            {
                await _emailSender.SendEmailAsync(
                    emailOptions.Epost,
                    "Sidnamn - Meddelande från webbformulär" + " - " + DateTime.Now.ToString(),
                    emailOptions.Meddelande,
                    emailOptions.Namn,
                    emailOptions.Telefon,
                    emailOptions.Company);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult getSubscriber(EmailOptions emailOptions)
        {
            if(emailOptions.Epost == null)
            {
                return RedirectToAction("Index");
            }

            var destinationFile = Path.GetFullPath("wwwroot/csv/Subscribers.csv");
            var logFile = System.IO.File.OpenWrite(destinationFile);

            using (StreamWriter file = new StreamWriter(logFile))
            {
                file.WriteLine("email");
            }
            using (StreamWriter sw = System.IO.File.AppendText(destinationFile))
            {
                sw.WriteLine(emailOptions.Epost);
            }

            return RedirectToAction("Index");
        }
    }
}
