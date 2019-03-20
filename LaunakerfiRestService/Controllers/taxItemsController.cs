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
using LaunakerfiRestService.Models;

namespace LaunakerfiRestService.Controllers
{
    public class taxItemsController : ApiController
    {
        private SalarySystemDBContext db = new SalarySystemDBContext();

        // GET: api/taxItems
        public IQueryable<taxItems> GettaxItems()
        {
            return db.taxItems;
        }

        // GET: api/taxItems/5
        [ResponseType(typeof(taxItems))]
        public IHttpActionResult GettaxItems(int id)
        {
            taxItems taxItems = db.taxItems.Find(id);
            if (taxItems == null)
            {
                return NotFound();
            }

            return Ok(taxItems);
        }

        // PUT: api/taxItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttaxItems(int id, taxItems taxItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taxItems.Id)
            {
                return BadRequest();
            }

            db.Entry(taxItems).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!taxItemsExists(id))
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

        // POST: api/taxItems
        [ResponseType(typeof(taxItems))]
        public IHttpActionResult PosttaxItems(taxItems taxItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.taxItems.Add(taxItems);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = taxItems.Id }, taxItems);
        }

        // DELETE: api/taxItems/5
        [ResponseType(typeof(taxItems))]
        public IHttpActionResult DeletetaxItems(int id)
        {
            taxItems taxItems = db.taxItems.Find(id);
            if (taxItems == null)
            {
                return NotFound();
            }

            db.taxItems.Remove(taxItems);
            db.SaveChanges();

            return Ok(taxItems);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool taxItemsExists(int id)
        {
            return db.taxItems.Count(e => e.Id == id) > 0;
        }
    }
}