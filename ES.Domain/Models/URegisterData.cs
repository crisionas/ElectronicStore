using System;
using System.Collections.Generic;
using System.Text;

namespace ES.Domain.Models
{
    public class URegisterData
    {
        public string Name { get; set; }

        public string Birth_date { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string IP { get; set; }

        public DateTime RegisteDateTime { get; set; }
    }
}
