using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace TestHangFire.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HangController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from hangfire web api !");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Welcome() 
        {
            BackgroundJob.Enqueue(()=>SendWelcomeEmail("Welcome to our app!"));
            return Ok("Welcome.")
        }

        private void SendWelcomeEmail(string email) 
        { 
            Console.WriteLine(email);
        }
    }
}