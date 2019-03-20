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
    public class personalDiscountModelsController : ApiController
    {
        private SalarySystemDBContext db = new SalarySystemDBContext();

        // GET: api/personalDiscountModels
        public IQueryable<personalDiscountModel> GetpersonalDiscountModels()
        {
            return db.personalDiscountModels;
        }

        // GET: api/personalDiscountModels/5
        [ResponseType(typeof(personalDiscountModel))]
        public IHttpActionResult GetpersonalDiscountModel(int id)
        {
            personalDiscountModel personalDiscountModel = db.personalDiscountModels.Find(id);
            if (personalDiscountModel == null)
            {
                return NotFound();
            }

            return Ok(personalDiscountModel);
        }

        // PUT: api/personalDiscountModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutpersonalDiscountModel(int id, personalDiscountModel personalDiscountModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personalDiscountModel.Id)
            {
                return BadRequest();
            }

            db.Entry(personalDiscountModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!personalDiscountModelExists(id))
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

        // POST: api/personalDiscountModels
        [ResponseType(typeof(personalDiscountModel))]
        public IHttpActionResult PostpersonalDiscountModel(personalDiscountModel personalDiscountModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.personalDiscountModels.Add(personalDiscountModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personalDiscountModel.Id }, personalDiscountModel);
        }

        // DELETE: api/personalDiscountModels/5
        [ResponseType(typeof(personalDiscountModel))]
        public IHttpActionResult DeletepersonalDiscountModel(int id)
        {
            personalDiscountModel personalDiscountModel = db.personalDiscountModels.Find(id);
            if (personalDiscountModel == null)
            {
                return NotFound();
            }

            db.personalDiscountModels.Remove(personalDiscountModel);
            db.SaveChanges();

            return Ok(personalDiscountModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool personalDiscountModelExists(int id)
        {
            return db.personalDiscountModels.Count(e => e.Id == id) > 0;
        }
    }
}