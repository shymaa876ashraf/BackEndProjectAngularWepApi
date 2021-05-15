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
    public class ProductWishlistController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ModelsFactory _modelFactory;
        public ProductWishlistController()
        {
            _modelFactory = new ModelsFactory();
        }
        [HttpGet]
        [ResponseType(typeof(WishListProductDto))]
        public IEnumerable<WishListProductDto> GetProductWishLost(int Id)
        {
            return db.ProductWishLists.ToList().Select(c => _modelFactory.CreateProductrWhishlistDto(c)).Where(l => l.whishlistId == Id);
        }
    }
}
