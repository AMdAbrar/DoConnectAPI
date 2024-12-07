using Azure;
using DoConnectService.Services;
using DoConnectUserEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        IUserServices _Iuserservices;

        public UserController(IUserServices userServices)
        {
            _Iuserservices = userServices;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _Iuserservices.GetProducts();
            return Ok(result);
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {

            _Iuserservices.AddUser(user);

            Response response = new Response();
            response.statuscode = "200";
            response.result = "Product added successfully..";
            response.message = "Success";

         
            return Ok(response);
        }
        [HttpPut]
        public IActionResult UpdateUser(User user, int id)
        {

            _Iuserservices.UpdateUser(user,id);
            object result = "Product Updated successfully..";
            return Ok(result);
        }
      
    }
    public class Response
    {
        public object result { get; set; }
        public string statuscode { get; set; }
        public string message { get; set; }
    }
}
