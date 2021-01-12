using System;
using System.Collections.Generic;
using System.Text;

namespace ES.Domain.Models
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Birth_date { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
