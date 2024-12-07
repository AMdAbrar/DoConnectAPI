using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectUserEntity;

namespace DoConnectRepositoty.Repository
{
    public interface IUserData
    {
        void AddUser(User user);
        void UpdateUser(User user, int id);
        void DeleteUser(User user, int id);
        List<User> GetProducts();

    }
}
