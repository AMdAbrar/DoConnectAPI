using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoConnectUserEntity
{
    public class User
    {
        [Key]
        public String UserName { get; set; }
        public String Password { get; set; }
    }
}
