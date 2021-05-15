using IdentityOAuth.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace IdentityOAuth.Controllers
{
    public class CartController : ApiController
    {
        private ApplicationDbContext  db = new ApplicationDbContext();

        // GET: api/Cart
        [HttpGet]
        public IQueryable<Cart> Getcart()
        {
            return db.carts;
        }
       
        // GET: api/Cart/5
        //   [Route("api/Cart/23")]

        public void postAddProductToCart(int id)
        {
            //get cart of current logged user
            var userID = "1";//User.Identity.GetUserId();

            var cartID = Getcart().Where(c => c.UserID == userID)
                                                           .Select(c => c.ID).FirstOrDefault();
            var productCart = new CartProduct() { CartID = cartID, ProductID = id ,Quantity=1};

            db.CartProducts.Add(productCart);
            db.SaveChanges();
   
        }
        [ResponseType(typeof(Cart))]
        public IHttpActionResult GetCart(int id)
        {
            Cart cart = db.carts.Find(id);
            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        // PUT: api/Cart/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCart(int id, Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart.ID)
            {
                return BadRequest();
            }

            db.Entry(cart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        // DELETE: api/Cart/5
        public IHttpActionResult DeleteProductFromCart(int id)
        {
            //get cart of current logged user
            var userID = "1";//User.Identity.GetUserId();
            var cartID = Getcart().Where(c => c.UserID == userID)
                                                       .Select(c => c.ID).FirstOrDefault();
            var productCart = new CartProduct() { CartID = cartID, ProductID = id, Quantity = 1 };
            db.CartProducts.Remove(productCart);
            db.SaveChanges();
            return Ok(productCart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartExists(int id)
        {
            return db.carts.Count(e => e.ID == id) > 0;
        }
    }
}
