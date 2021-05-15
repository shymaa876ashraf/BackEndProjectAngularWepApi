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
    public class ProductCartController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ModelsFactory _modelFactory;
        public ProductCartController()
        {
            _modelFactory = new ModelsFactory();
        }
        [HttpGet]
        [ResponseType(typeof(CartProductDto))]
        public IEnumerable<CartProductDto> GetProductCart(int CartID)
        {
            return db.CartProducts.ToList().Select(c => _modelFactory.CreateProductrCartDto(c)).Where(l=>l.cartId==CartID);
        }
    }
}

