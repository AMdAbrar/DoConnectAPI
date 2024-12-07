using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectRepositoty.Repository;
using DoConnectUserEntity;

namespace DoConnectService.Services
{
    public class AuthoUserService : IAuthoUserService
    {
        IAuthUserRepo _authoUserRepo;
        public AuthoUserService(IAuthUserRepo userInfoRepository)
        {
            _authoUserRepo = userInfoRepository;
        }

        public void Register(AuthoUser authouser)
        {
            _authoUserRepo.Register(authouser);
        }
        public AuthoUser Login(AuthoUser authouser)
        {
            return _authoUserRepo.Login(authouser);
        }
    }
}
