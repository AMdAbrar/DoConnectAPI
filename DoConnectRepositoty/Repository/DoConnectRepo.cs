using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectRepositoty.Data;
using DoConnectUserEntity;

namespace DoConnectRepositoty.Repository
{
    public class DoConnectRepo : IDoConnectRepo
    {
        UserDbConnect _userDbConnect;
        public DoConnectRepo(UserDbConnect userDb)
        {
            _userDbConnect = userDb;
        }

   
        public DoConnectLogin LoginUser(DoConnectLogin loginDto)
        {
            DoConnectLogin auth = null;
            var result = _userDbConnect.DoConnectRegs.Where(obj => obj.Email == loginDto.Email && obj.Password == loginDto.Password).ToList();
            //if (result.Count > 0)
            //{
            //    auth = result[0];
            //}
            return auth;
        }

        public Task LogoutUser()
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(DoConnectRegister registerDto)
        {
            _userDbConnect.DoConnectRegs.Add(registerDto);
            _userDbConnect.SaveChanges();

        }

        
    }
}
