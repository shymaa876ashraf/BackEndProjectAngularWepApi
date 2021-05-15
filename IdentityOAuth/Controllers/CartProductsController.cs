using IdentityOAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace IdentityOAuth.Controllers
{
    public class CartProductsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ModelsFactory _modelFactory;
        public CartProductsController()
        {
            _modelFactory = new ModelsFactory();
        }
        [HttpGet]
        [ResponseType(typeof(CartProductDto))]
        public IEnumerable<CartProductDto> GetProductCart(int Id)
        {
            return db.CartProducts.ToList().Select(c => _modelFactory.CreateProductrCartDto(c)).Where(l => l.cartId == Id);
        }

        //[HttpDelete]
        //public void DeleteProductfromCart(int id)
        //{
        //    //get cart of current logged user
        //    var userID = "1";//User.Identity.GetUserId();

        //    var cartID = Getcart().Where(c => c.UserID == userID)
        //                                                   .Select(c => c.ID).FirstOrDefault();
        //    var productCart = new CartProduct() { CartID = cartID, ProductID = id, Quantity = 1 };

        //    db.CartProducts.Remove(productCart);
        //    db.SaveChanges();

        //}
    }
}
