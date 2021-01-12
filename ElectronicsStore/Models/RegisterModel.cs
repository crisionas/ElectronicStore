using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Necessary to fill space")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Necessary to fill space")]
        [MinAge(ErrorMessage = "You must be 18 years of age or older.")]
        public string Birth_date { get; set; }

        [Required(ErrorMessage = "Necessary to fill space")]
        [EmailAddress(ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords are not the same")]
        public string ConfirmPassword { get; set; }


        public class MinAgeAttribute : ValidationAttribute
        {

            public override bool IsValid(object value)
            {
                if (DateTime.Today.AddYears(-18) >= Convert.ToDateTime(value))
                    return true;
                return false;
            }
        }

    }
}
