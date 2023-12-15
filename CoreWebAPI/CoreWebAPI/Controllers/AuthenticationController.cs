using CoreWebAPI.Interfaces;
using CoreWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        public AuthenticationController(IJwtService jwtService)
        {
            this._jwtService=jwtService;
        }


        [HttpPost]
        public IActionResult Login(UserCredentials userCredentials)
        {
            var token = _jwtService.Authentication(userCredentials.username, userCredentials.password);
            return Ok(token);
        }
    }
}
