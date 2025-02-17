﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoConnectUserEntity
{
    public class DoConnectRegister
    {
        [Key]
        public int Id { get; set; }

        [Required][EmailAddress]
        public string Email { get; set; }

        [Required][DataType(DataType.Password)]
        public string Password { get; set; }

        [Required][DataType(DataType.Password)][Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
