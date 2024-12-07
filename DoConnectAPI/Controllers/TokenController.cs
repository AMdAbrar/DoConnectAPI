//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using DoConnectRepositoty.Data;
//using DoConnectService.Services;
//using DoConnectUserEntity;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//////it will take username and password are valid then it will return the access token
//namespace DoConnectAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]

//    //private IAuthoUserService _authoUserService;
//    //public TokenController(IAuthoUserService authoUserService)
//    //{
//    //    _authoUserService = authoUserService;
//    //}
//    public class TokenController : ControllerBase
//    {
//        public IConfiguration _configuration;
//        private readonly UserDbConnect _context;

//        public TokenController(IConfiguration config, UserDbConnect context)
//        {
//            _configuration = config;
//            _context = context;

//        }
//        [HttpPost("Login")]
//        public async Task<IActionResult> Post(AuthoUser _userData)
//        {

//            if (_userData != null && _userData.Email != null && _userData.Password != null)
//            {
//                var user = await GetUser(_userData.Email, _userData.Password);

//                if (user != null)
//                {
//                    //create claims details based on the user information
//                    var claims = new[] {
//                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
//                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
//                    new Claim("Id", user.UserId.ToString()),
//                    new Claim("FirstName", user.Firstname),
//                    new Claim("LastName", user.Lastname),
//                    new Claim("Email", user.Email),
//                   };

//                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

//                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

//                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
//                }
//                else
//                {
//                    return BadRequest("Invalid credentials");
//                }
//            }
//            else
//            {
//                return BadRequest();
//            }
//        }

//        private async Task<AuthoUser> GetUser(string email, string password)
//        {
//            AuthoUser userInfo = null;
//            var result = _context.AuthoUsers.Where(u => u.Email == email && u.Password == password);
//            foreach (var item in result)
//            {
//                userInfo = new AuthoUser();
//                userInfo.UserId = item.UserId;
//                userInfo.Firstname = item.Firstname;
//                userInfo.Lastname = item.Lastname;
//                userInfo.Email = item.Email;
//                userInfo.Mobile = item.Mobile;
//            }
//            return userInfo;
//            //return await _context.UserInfos.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
//        }
        
//    }
//}
