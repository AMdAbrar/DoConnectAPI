using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectRepositoty.Data;
using DoConnectUserEntity;
using Microsoft.EntityFrameworkCore;

namespace DoConnectRepositoty.Repository
{
    public class UserData : IUserData
    {

        UserDbConnect _dbConnect;
        public UserData(UserDbConnect dbConnect)
        {
            _dbConnect = dbConnect;
        }

        public void AddUser(User user)
        {
            _dbConnect.Users.Add(user);
            _dbConnect.SaveChanges();
        }

        public void DeleteUser(User user, int id)
            
        {
            _dbConnect.Users.Remove(user);
            _dbConnect.SaveChanges();

        }

        public List<User> GetProducts()
        {
            List<User> list = _dbConnect.Users.ToList();
            return list;
        }

        public void UpdateUser(User user, int id)
        {
            _dbConnect.Users.Update(user);
            _dbConnect.SaveChanges();
        }
    }
}
