using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectUserEntity;

namespace DoConnectRepositoty.Repository
{
    public interface IDoConnectRepo
    {
        //public void AddUserRegister(DoConnectRegister doConnect);
        //public void AddLoginData(DoConnectRegister doConnect);

        public void RegisterUser(DoConnectRegister registerDto);
        public DoConnectLogin LoginUser(DoConnectLogin loginDto); 
        Task LogoutUser();


    }

  
   
}
