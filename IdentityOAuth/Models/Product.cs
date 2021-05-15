using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace IdentityOAuth.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category category { get; set; }
        [ForeignKey("BrandID")]
        public virtual Brands barnd { get; set; }
        [JsonIgnore]
        public virtual ICollection<CartProduct> CartProducts { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProductWishList> ProductWishLists { get; set; }

    }
}