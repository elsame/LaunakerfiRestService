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
    public class taxOfficeModelsController : ApiController
    {
        private SalarySystemDBContext db = new SalarySystemDBContext();

        // GET: api/taxOfficeModels
        public IQueryable<taxOfficeModel> GettaxOfficeModels()
        {
            return db.taxOfficeModels;
        }

        // GET: api/taxOfficeModels/5
        [ResponseType(typeof(taxOfficeModel))]
        public IHttpActionResult GettaxOfficeModel(int id)
        {
            taxOfficeModel taxOfficeModel = db.taxOfficeModels.Find(id);
            if (taxOfficeModel == null)
            {
                return NotFound();
            }

            return Ok(taxOfficeModel);
        }

        // PUT: api/taxOfficeModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttaxOfficeModel(int id, taxOfficeModel taxOfficeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taxOfficeModel.Id)
            {
                return BadRequest();
            }

            db.Entry(taxOfficeModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!taxOfficeModelExists(id))
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

        // POST: api/taxOfficeModels
        [ResponseType(typeof(taxOfficeModel))]
        public IHttpActionResult PosttaxOfficeModel(taxOfficeModel taxOfficeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.taxOfficeModels.Add(taxOfficeModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = taxOfficeModel.Id }, taxOfficeModel);
        }

        // DELETE: api/taxOfficeModels/5
        [ResponseType(typeof(taxOfficeModel))]
        public IHttpActionResult DeletetaxOfficeModel(int id)
        {
            taxOfficeModel taxOfficeModel = db.taxOfficeModels.Find(id);
            if (taxOfficeModel == null)
            {
                return NotFound();
            }

            db.taxOfficeModels.Remove(taxOfficeModel);
            db.SaveChanges();

            return Ok(taxOfficeModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool taxOfficeModelExists(int id)
        {
            return db.taxOfficeModels.Count(e => e.Id == id) > 0;
        }
    }
}