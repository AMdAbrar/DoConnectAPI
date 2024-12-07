using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoConnectUserEntity;
using Microsoft.EntityFrameworkCore;

namespace DoConnectRepositoty.Data
{
    public class UserDbConnect: DbContext// DbContext is for db connection
    {
        public UserDbConnect(DbContextOptions<UserDbConnect> options) : base(options)
        {       


        }

        public DbSet<User> Users { get; set; }// if any property we set DBset it could be table name 
        public DbSet<AuthoUser> AuthoUsers { get; set; }// if any property we set DBset it could be table name 
        //public DbSet<DoConnectRegister> DoConnects {  get; set; }
        public DbSet<DoConnectRegister> DoConnectRegs { get; set; }




    }
}
