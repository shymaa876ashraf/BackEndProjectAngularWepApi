using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentityOAuth.Models
{
    public class ProductWishList
    {
        public int ID { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
        [ForeignKey("WishList")]
        public int wishListID { get; set; }
        [JsonIgnore]
        public virtual Whichlist WishList { get; set; }
    }
}