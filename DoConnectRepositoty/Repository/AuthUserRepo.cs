using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectRepositoty.Data;
using DoConnectUserEntity;

namespace DoConnectRepositoty.Repository
{
    public class AuthUserRepo : IAuthUserRepo
    {
        UserDbConnect _userDbConnect;

        public AuthUserRepo(UserDbConnect userDbConnect)
        {
            _userDbConnect = userDbConnect;
        }


        public void Register(AuthoUser authouser)
        {
            _userDbConnect.AuthoUsers.Add(authouser);
            _userDbConnect.SaveChanges();
        }
        public AuthoUser Login(AuthoUser authouser)
        {
            AuthoUser auth = null;
            var result = _userDbConnect.AuthoUsers.Where(obj => obj.Email == authouser.Email && obj.Password == authouser.Password).ToList();
            if (result.Count > 0)
            {
                auth = result[0];
            }
            return auth;
        }

        
    }
}
