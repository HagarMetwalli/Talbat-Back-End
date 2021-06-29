using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Talbat.Dtos;
using Talbat.IServices;
using Talbat.Models;

namespace Talbat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailingController : ControllerBase
    {
        private readonly IMailingService _mailingService;

        public MailingController(IMailingService mailingService) => _mailingService = mailingService;

        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequestDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            try
            {
                await _mailingService.SendEmailAsync(dto.ToEmail, dto.Subject, dto.Body, dto.Attachments);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
           

        }

        [HttpPost("welcome")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> SendWelcomeEmail([FromBody] WelcomeRequestDto dto)
        {
            using (var db = new TalabatContext())
            {
                var exist = db.TempPartnerRegisterationDetails.FirstOrDefault(x => x.PartnerEmail == dto.Email.ToLower());
                if (exist == null)
                {
                    return NotFound();
                }
                else 
                {
                    try
                    {
                        var filePath = "E://1ITI//ITI Graduation Project//project//HagarMetwalli//Talabat//Talbat-Back-End//Templetes//EmailTemplate.html";

                        var str = new StreamReader(filePath);

                        var mailText = str.ReadToEnd();
                        str.Close();

                        mailText = mailText.Replace("[username]", dto.UserName).Replace("[email]", dto.Email).Replace("[password]", dto.Password);

                        await _mailingService.SendEmailAsync(dto.Email, "Welcome to our channel", mailText);
                        return Ok();
                    }
                    catch
                    {

                        return BadRequest();
                    }
                }  
            }

        }
    }
}
