using DoConnectService.Services;
using DoConnectUserEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoConnectController : ControllerBase
    {

        IDoConnectService _service; 
        public DoConnectController(IDoConnectService service)
        {
            _service = service;
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] DoConnectRegister doConnect)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }
            _service.RegisterUser(doConnect);
            return Ok("User registered successfully.");

            //var result = _service.RegisterUser(doConnect);
            //if (result.Succeeded)
            //{
            //    return Ok("User registered successfully.");
            //}
            //foreach (var error in result.Errors) { 
            //    ModelState.AddModelError(string.Empty, error.Description); 
            //}
            //return BadRequest(ModelState);

        }


        [HttpPost("Login")]
        public IActionResult Login([FromBody] DoConnectLogin doConnectlogin)
        {
            _service.LoginUser(doConnectlogin);
            return Ok("Login successfully");

        }
    }
}
