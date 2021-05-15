using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace IdentityOAuth.Models
{
    //[DataContract]
    public class Category
    {
        //[DataMember]
        public int ID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public virtual ICollection<Product> products { get; set; }
    }
}