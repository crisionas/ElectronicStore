using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;
using ES.Domain.Enums;

namespace ES.Domain.Entities
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birth_Date { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(50,MinimumLength = 5,ErrorMessage = "Password cannot be shorter than 5 characters.")]
        public string Password { get; set; }

        public DateTime RegisterDateTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastLogin { get; set; }

        [StringLength(30)]
        public string LastIp { get; set; }

        public URole Level { get; set; }
    }
}
