using AspnCore_EnviaEmail.Models;
using AspnCore_EnviaEmail.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AspnCore_EnviaEmail.Controllers
{
    public class TesteEmailController : Controller
    {
        private readonly IEmailSender _emailSender;

        public TesteEmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        //get
        public IActionResult EnviarEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarEmail(EmailModel email)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TesteEnvioEmail(email.Destino, email.Assunto, email.Mensagem).GetAwaiter();
                    return RedirectToAction("EmailEnviado");
                }
                catch (Exception)
                {
                    return RedirectToAction("EmailFalhou");
                }
            }
            return View(email);
        }

        public async Task TesteEnvioEmail(string email, string assunto, string mensagem)
        {
            try
            {
                //email destino, assunto do email, mensagem a enviar
                await _emailSender.SendEmailAsync(email, assunto, mensagem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult EmailEnviado()
        {
            return View();
        }

        public ActionResult EmailFalhou()
        {
            return View();
        }
    }
}