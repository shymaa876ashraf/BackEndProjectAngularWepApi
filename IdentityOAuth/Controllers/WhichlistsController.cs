using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using IdentityOAuth.Models;

namespace IdentityOAuth.Controllers
{
    public class WhichlistsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Whichlists
        public IQueryable<Whichlist> Getwhichlist()
        {
            return db.whichlist;
        }

        // GET: api/Whichlists/5
        [ResponseType(typeof(Whichlist))]
        public IHttpActionResult GetWhichlist(int id)
        {
            Whichlist whichlist = db.whichlist.Find(id);
            if (whichlist == null)
            {
                return NotFound();
            }

            return Ok(whichlist);
        }

        // PUT: api/Whichlists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWhichlist(int id, Whichlist whichlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != whichlist.ID)
            {
                return BadRequest();
            }

            db.Entry(whichlist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WhichlistExists(id))
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

        // POST: api/Whichlists
        public void postAddProductTowishList(int id)
        {
            //get cart of current logged user
            var userID = "1";//User.Identity.GetUserId();

            var wishListID = Getwhichlist().Where(c => c.UserID == userID)
                                                           .Select(c => c.ID).FirstOrDefault();
            var productWishList = new ProductWishList() { wishListID = wishListID, ProductID = id };

            db.ProductWishLists.Add(productWishList);
            db.SaveChanges();

        }

        // DELETE: api/Whichlists/5
        [ResponseType(typeof(Whichlist))]
        public IHttpActionResult DeleteWhichlist(int id)
        {
            Whichlist whichlist = db.whichlist.Find(id);
            if (whichlist == null)
            {
                return NotFound();
            }

            db.whichlist.Remove(whichlist);
            db.SaveChanges();

            return Ok(whichlist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WhichlistExists(int id)
        {
            return db.whichlist.Count(e => e.ID == id) > 0;
        }
    }
}