using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ES.Domain.Entities
{
    public class ElectroProducts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int CategoryId { get; set; }
        
        [Required]
        public int BrandId { get; set; }

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

        public byte[] ProductImage1 { get; set; }

        public byte[] ProductImage2 { get; set; }

        public byte[] ProductImage3 { get; set; }
        [Required]
        public ElectroCategories Category { get; set; }

        [Required]
        public ElectroBrands Brand { get; set; }
    }
}
