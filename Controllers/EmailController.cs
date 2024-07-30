using HelpDeskWebSite.Data;
using HelpDeskWebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskWebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;
//        private readonly IEmailReceiverService _emailReceiverService;
        
        public EmailController(IEmailService emailService, ApplicationDbContext context)
        {
            _emailService = emailService;
            _context = context;
            
        }
/*
        [HttpGet("sendEmail")]
        public async Task<IActionResult> Get()
        {
            await _emailService.SendEmailAsync("kyrylsolominskyi@gmail.com", "Some subject", "Specify the html content here");
            return Ok();
        }*/

        /*[HttpGet("fetch")]
        public async Task<IActionResult> FetchEmails()
        {
            await _emailReceiverService.EmailReceiver();
            return Ok("Emails fetched and logged.");
        }*/

/*        [HttpPost]
        [Consumes("multipart/form-data")]
        public IActionResult ReceiveEmail([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Process the file (e.g., save it to the server, read its contents, etc.)
            // For now, we just return the file name as a success response
            return Ok();
        }*/

        [HttpPost]
        public async Task<IActionResult> PostEmailMessage([FromForm] EmailMessage emailMessage, [FromForm] List<IFormFile> attachments)
        {
            /*            if (attachments != null && attachments.Count > 0)
                        {
                            Response.ContentType = "multipart/form-data";
                        }
                        else
                        {
                            Response.ContentType = "application/x-www-form-urlencoded";
                        }*/
            if(ModelState.IsValid) 
            {
                _context.Add(emailMessage);
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest();
            }

            Response.ContentType = "application/x-www-form-urlencoded";




            // Process the emailMessage object
            // For demonstration, let's just return it as a JSON response
/*            var response = new
            {
                body = "This URL has no default content configured. <a href=\"https://webhook.site/#!/view/d4d16e16-3557-496e-9947-896206e2cf65\">View in Webhook.site</a>.",
                status = 200
            };*/

            // Return the response with 200 status code
            return Ok();
        }
    }
}
