using Microsoft.AspNetCore.Mvc;
using OBI.Business.Models;
using OBI.Data.Context;

namespace OBI.Api.Controllers
{
    [ApiController]
    [Route("v1/user")]
    public class UserController : ControllerBase
    {        
        [HttpGet]
        public IActionResult GetAllUsers([FromServices]MyDbContext context)
        {
            var users = context.Users.ToList();
            return Ok(users);
        }
    }
}
