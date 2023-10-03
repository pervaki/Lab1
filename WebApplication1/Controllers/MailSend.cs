using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;


namespace Lab1.Controllers
{
    public class MailSend : Controller
    {
        private readonly IEmailSender _emailSender;

        public MailSend(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(string email, string message)
        {
            try
            {
                await _emailSender.SendEmailAsync(email, "Subject", message);
                ViewData["Message"] = "Email sent successfully!";
            }
            catch (Exception ex)
            {
                ViewData["Error"] = $"Error sending email: {ex.Message}";
            }

            return View("~/Views/Mail/Index.cshtml");
        }
    }
}
