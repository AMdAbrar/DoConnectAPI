using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectUserEntity;

namespace DoConnectService.Services
{
    public interface IDoConnectService
    {
        public void RegisterUser(DoConnectRegister registerDto);
     public DoConnectLogin LoginUser(DoConnectLogin loginDto); 
        Task LogoutUser();
    }
}
