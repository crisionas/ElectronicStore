using System;
using System.Collections.Generic;
using System.Text;
using ES.Domain.Enums;

namespace ES.Domain.Models
{
    public class ULoginResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public URole Role { get; set; }
    }
}
