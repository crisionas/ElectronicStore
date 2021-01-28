using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ES.Domain.Entities
{
    public class ElectroBrands
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public ICollection<ElectroProducts> Products { get; set; }
    }
}
