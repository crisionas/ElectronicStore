using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ES.Domain.Entities
{
    public class ApplianceProducts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(80)]
        public string Name { get; set; }
        [Required]
        public ApplianceCategories Category { get; set; }

        [Required]
        public ApplianceBrands Brand { get; set; }

        [Required]
        [StringLength(80)]
        public string Details { get; set; }

        [Required]
        [StringLength(50)]
        public string Mark { get; set; }

        [Required]
        [StringLength(10)]
        public string Price { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        public string ProductImage1 { get; set; }

        public string ProductImage2 { get; set; }

        public string ProductImage3 { get; set; }

    }
}
