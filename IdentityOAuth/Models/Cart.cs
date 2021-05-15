using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentityOAuth.Models
{
    public class Cart
    {
        public Cart()
        {
            CartProducts = new List<CartProduct>();
        }
        public int ID { get; set; }
        public string UserID { get; set; }
        [ForeignKey("UserID"), Key]
        public virtual UserModel user { get; set; }
        [JsonIgnore]
        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}