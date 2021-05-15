using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentityOAuth.Models
{
    public class ApplicationDbContext:IdentityDbContext //user/role/claims
    {
        public ApplicationDbContext():base("CS")
        {

        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Brands> beands { get; set; }
        public virtual DbSet<Cart> carts { get; set; }
        public virtual DbSet<Whichlist> whichlist { get; set; }
        public virtual DbSet<CartProduct> CartProducts { get; set; }
        public virtual DbSet<ProductWishList> ProductWishLists { get; set; }


    }
}