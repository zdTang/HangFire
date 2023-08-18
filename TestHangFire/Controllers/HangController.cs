using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace TestHangFire.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangController : ControllerBase
    {
        [Microsoft.AspNetCore.Mvc.HttpGet]


        [HttpPost]
        [Route("[action]")]
        public IActionResult Welcome()
        {
            BackgroundJob.Enqueue(() => SendWelcomeEmail("Welcome to our app!",null));
            return Ok(" Welcome.");
        }

        public void SendWelcomeEmail(string email, PerformContext context) 
        {
            string jobId = context.BackgroundJob.Id;
            Console.WriteLine(email);
            Console.WriteLine($"Job ID:{jobId}, Welcome.");
        }
    } 
}