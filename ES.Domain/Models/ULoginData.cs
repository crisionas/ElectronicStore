using System;
using System.Collections.Generic;
using System.Text;
using ES.Domain.Enums;

namespace ES.Domain.Models
{
    public class ULoginData
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string LoginIP { get; set; }
        public DateTime LoginDate { get; set; }
        public URole Role { get; set; }
    }
}
