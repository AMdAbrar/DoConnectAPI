using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectRepositoty.Repository;
using DoConnectUserEntity;
using Microsoft.EntityFrameworkCore;

namespace DoConnectService.Services
{

    public class DoConnectRegisterService : IDoConnectService
    {
        IDoConnectRepo _doRepo;
        public DoConnectRegisterService(IDoConnectRepo doRepo)
        {
            _doRepo = doRepo;
        }
       
        public void LoginUser(DoConnectLogin loginDto)
        {
             _doRepo.LoginUser(loginDto);

        }

        public Task LogoutUser()
        {
            throw new NotImplementedException();
        }

        public IDoConnectRepo Get_doRepo()
        {
            return _doRepo;
        }

        public void RegisterUser(DoConnectRegister registerDto)
        {
            throw new NotImplementedException();
        }

        DoConnectLogin IDoConnectService.LoginUser(DoConnectLogin loginDto)
        {
            throw new NotImplementedException();
        }

        //public DoConnectRegister RegisterUser(DoConnectRegister registerDto, IDoConnectRepo _doRepo)
        //{
        //    //var result = _doRepo.RegisterUser(registerDto);
        //    return result;

        //}
    }
}
