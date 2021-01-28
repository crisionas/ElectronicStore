using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ES.Domain.Entities
{
    public class ApplianceCategories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        
        public ICollection<ApplianceProducts> Products { get; set; }
    }
}
