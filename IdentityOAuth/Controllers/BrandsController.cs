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
    public class BrandsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ModelsFactory _modelFactory;
        public BrandsController()
        {
            _modelFactory = new ModelsFactory();
        }
        // GET: api/Brands
        [ResponseType(typeof(BrandsDto))]
        public IEnumerable<BrandsDto> Getbeands()
        {
            return db.beands.ToList().Select(c => _modelFactory.CreateBrand(c));
        }

        // GET: api/Brands/5
        [ResponseType(typeof(Brands))]
        public IHttpActionResult GetBrands(int id)
        {
            Brands brands = db.beands.Find(id);
            if (brands == null)
            {
                return NotFound();
            }

            BrandsDto brandsDto = new BrandsDto();
            brandsDto.ID = brands.ID;
            brandsDto.BrandName = brands.BrandName;
            return Ok(brandsDto);//serialize to josn  
        }

            // PUT: api/Brands/5
            [ResponseType(typeof(void))]
        public IHttpActionResult PutBrands(int id, Brands brands)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brands.ID)
            {
                return BadRequest();
            }

            db.Entry(brands).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandsExists(id))
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

        // POST: api/Brands
        [ResponseType(typeof(Brands))]
        public IHttpActionResult PostBrands(Brands brands)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.beands.Add(brands);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = brands.ID }, brands);
        }

        // DELETE: api/Brands/5
        [ResponseType(typeof(Brands))]
        public IHttpActionResult DeleteBrands(int id)
        {
            Brands brands = db.beands.Find(id);
            if (brands == null)
            {
                return NotFound();
            }

            db.beands.Remove(brands);
            db.SaveChanges();

            return Ok(brands);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrandsExists(int id)
        {
            return db.beands.Count(e => e.ID == id) > 0;
        }
    }
}