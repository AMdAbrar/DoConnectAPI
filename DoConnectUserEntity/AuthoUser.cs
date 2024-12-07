using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoConnectUserEntity
{
    public class AuthoUser
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Password { get; set; }

        public int Mobile { get; set; }
        public string? Role { get; set; }
    }
}
