using EmailService.Service;
using Microservices.API.Entities.Models.MailModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Microservices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly IMailingService _mailingService;

        public MailsController(IMailingService mailingService)
        {
            _mailingService = mailingService;
        }

        [HttpGet("ProjectSignup/{mail}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<IActionResult> PostNewProject([FromRoute] string mail)
        {
            try
            {
                string body = $"Hello Mr.Mario\nThis message is to inform you that: {mail} wants to contact with you about new project.";
                await _mailingService.SendMailAsync("New project signup", body);
                return Ok("Message was sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("PickAppointment")]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<IActionResult> PickAppointment(Appointment appointment)
        {
            try
            {
                var filePath = $"{Directory.GetCurrentDirectory()}\\Templates\\pick-an-appointment.html";
                var streamReader = new StreamReader(filePath);
                var mailText = streamReader.ReadToEnd();
                streamReader.Close();
                // Replace placeholders with actual data
                mailText =
                    mailText.Replace("[emailSubject]", "New Appointment Request")
                    .Replace("[Email]", appointment.Email)
                    .Replace("[Phone]", appointment.Phone)
                    .Replace("[Name]", appointment.Name)
                    .Replace("[Message]", appointment.Message);

                await _mailingService.SendMailAsync("New Appointment Request", mailText);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
