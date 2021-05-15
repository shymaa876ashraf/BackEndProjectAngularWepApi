using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentityOAuth.Models
{
    public class Brands
    {
        public int ID { get; set; }
        [Required]
        [StringLength(30)]
        public string BrandName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}