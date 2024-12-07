using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectUserEntity;

namespace DoConnectService.Services
{
    public interface IAuthoUserService
    {
        void Register(AuthoUser authouser);
        AuthoUser Login(AuthoUser authouser);
        //Task GetUserByEmailAsync(string email);
    }
}
