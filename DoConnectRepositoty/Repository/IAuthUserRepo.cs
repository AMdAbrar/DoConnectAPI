using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectUserEntity;

namespace DoConnectRepositoty.Repository
{
    public interface IAuthUserRepo
    {
        void Register(AuthoUser authouser);
        AuthoUser Login(AuthoUser authouser);
    }
}
