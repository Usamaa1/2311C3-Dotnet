using Authentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] SendMail request)
        {
            if (string.IsNullOrEmpty(request.To) || string.IsNullOrEmpty(request.Subject) || string.IsNullOrEmpty(request.Body))
                return BadRequest("All fields are required.");

            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("usamariaz@aptechnorth.edu.pk", "sxxl unez sdzb njbb"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("usamariaz@aptechnorth.edu.pk", "Aptech North Nazimabad"),
                    Subject = request.Subject,
                    Body = request.Body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(request.To);

                await smtpClient.SendMailAsync(mailMessage);

                return Ok("Email sent successfully.");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Error sending email: {ex.Message}");
            }
        }
    }
}