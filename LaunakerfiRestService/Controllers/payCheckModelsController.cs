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
    public class payCheckModelsController : ApiController
    {
        private SalarySystemDBContext db = new SalarySystemDBContext();

        // GET: api/payCheckModels
        public IQueryable<payCheckModel> GetPayCheck()
        {
            return db.PayCheck;
        }

        // GET: api/payCheckModels/5
        [ResponseType(typeof(payCheckModel))]
        public IHttpActionResult GetpayCheckModel(int id)
        {
            payCheckModel payCheckModel = db.PayCheck.Find(id);
            if (payCheckModel == null)
            {
                return NotFound();
            }

            return Ok(payCheckModel);
        }

        // PUT: api/payCheckModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutpayCheckModel(int id, payCheckModel payCheckModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != payCheckModel.Id)
            {
                return BadRequest();
            }

            db.Entry(payCheckModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!payCheckModelExists(id))
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

        // POST: api/payCheckModels
        [ResponseType(typeof(payCheckModel))]
        public IHttpActionResult PostpayCheckModel(payCheckModel payCheckModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PayCheck.Add(payCheckModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = payCheckModel.Id }, payCheckModel);
        }

        // DELETE: api/payCheckModels/5
        [ResponseType(typeof(payCheckModel))]
        public IHttpActionResult DeletepayCheckModel(int id)
        {
            payCheckModel payCheckModel = db.PayCheck.Find(id);
            if (payCheckModel == null)
            {
                return NotFound();
            }

            db.PayCheck.Remove(payCheckModel);
            db.SaveChanges();

            return Ok(payCheckModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool payCheckModelExists(int id)
        {
            return db.PayCheck.Count(e => e.Id == id) > 0;
        }
    }
}