
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DoConnectService.Services;
using DoConnectUserEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace DoConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoController : ControllerBase
    {
        IAuthoUserService _authoUserService;
        IConfiguration _configuration;
        ILogger<AuthoController> _logger;//
        public AuthoController(IAuthoUserService authoUserService, IConfiguration configuration, ILogger<AuthoController> logger)
        {
            _authoUserService = authoUserService;
            _configuration = configuration;
            _logger = logger;
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] AuthoUser authoUser)
        {
            try
            {
                _authoUserService.Register(authoUser);//attempt to register the user

                _logger.LogInformation("error message");
                return Ok("Register successfully!!");

            }
            catch (Exception ex)
            {
                // Log the exception if needed
                // _logger.LogError(ex, "Error occurred during user registration");

                // Return a 500 Internal Server Error response with the error message
                //_logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }

        }
        //[HttpPost("Login")]
        //public IActionResult Login([FromBody] AuthoUser authoUser)
        //{
        //    try
        //    {
        //        AuthoUser user = _authoUserService.Login(authoUser);
        //        if (user != null)
        //            return Ok("Login success!!");
        //        else
        //            return NotFound();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "An unexpected error occurred. Please try again later.");
        //    }


        //}
        //
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthoUser loginDto)
        {
            // Example: Validate user credentials (e.g., check username and password from DB)
            //if (loginDto.Email != "testuser" || loginDto.Password != "testpassword")
            //{
            //    return Unauthorized("Invalid credentials");
            //}

            // Generate JWT token
            var token = GenerateJwtToken1(loginDto.Password);
            return Ok(new { Token = token });
        }
        private string GenerateJwtToken1(string username)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            // Validate configuration values
            var key = jwtSettings["Key"];
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), "JWT Key is not configured");
            }

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, username),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["ExpireMinutes"])),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
