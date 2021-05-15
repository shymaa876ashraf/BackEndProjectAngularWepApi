using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentityOAuth.Models
{
    public class Whichlist
    {
        public Whichlist()
        {
            Products = new List<ProductWishList>();
        }
        public int ID { get; set; }
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual UserModel user { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProductWishList> Products { get; set; }

    }
}