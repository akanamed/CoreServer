using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Login Get Method";
        }

        [HttpGet]
        public string GetLogin()
        {
            return "Login GetLogin Method";
        }
    }
}
