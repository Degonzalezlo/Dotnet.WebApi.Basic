using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TODO.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController() { 
        }
        [HttpGet]
        public async Task <IActionResult> GetHelloWorld(){
            return Ok ("Hello World");

        }
    }
}
