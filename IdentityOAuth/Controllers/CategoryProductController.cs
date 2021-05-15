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
    public class CategoryProductController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ModelsFactory _modelFactory;
        public CategoryProductController()
        {
            _modelFactory = new ModelsFactory();
        }
        [HttpGet]
        [ResponseType(typeof(ProductDto))]
        public IEnumerable<ProductDto> GetAllProductsByCategoryID(int id)
        {
            var productDtos =db.Products.ToList().Select(c => _modelFactory.Create(c)).Where(s => s.CategoryID == id);
            return productDtos;
        }
    }
}
