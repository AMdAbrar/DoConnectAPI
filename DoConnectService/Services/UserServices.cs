using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using DoConnectRepositoty.Repository;
using DoConnectService.Services;
using DoConnectUserEntity;

namespace DoConnectService.Services
{
    public class UserServices : IUserServices
    {
        IUserData _iuserdatarepo;
     public UserServices(IUserData iuser)
        {
            _iuserdatarepo = iuser;
        }


        public void AddUser(User user)
        {
            _iuserdatarepo.AddUser(user);
        }

        public void DeleteUser(User user, int id)
        {
            _iuserdatarepo.DeleteUser(user, id);
        }

        public List<User> GetProducts()
        {
            return _iuserdatarepo.GetProducts();

        }

        public void UpdateUser(User user, int id)
        {
            _iuserdatarepo.UpdateUser(user, id);
        }
    }
     
    
}
