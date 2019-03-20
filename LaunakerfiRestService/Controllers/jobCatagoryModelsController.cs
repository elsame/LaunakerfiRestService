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
    public class jobCatagoryModelsController : ApiController
    {
        private SalarySystemDBContext db = new SalarySystemDBContext();

        // GET: api/jobCatagoryModels
        public IQueryable<jobCatagoryModel> GetjobCatagoryModels()
        {
            return db.jobCatagoryModels;
        }

        // GET: api/jobCatagoryModels/5
        [ResponseType(typeof(jobCatagoryModel))]
        public IHttpActionResult GetjobCatagoryModel(int id)
        {
            jobCatagoryModel jobCatagoryModel = db.jobCatagoryModels.Find(id);
            if (jobCatagoryModel == null)
            {
                return NotFound();
            }

            return Ok(jobCatagoryModel);
        }

        // PUT: api/jobCatagoryModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutjobCatagoryModel(int id, jobCatagoryModel jobCatagoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobCatagoryModel.Id)
            {
                return BadRequest();
            }

            db.Entry(jobCatagoryModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!jobCatagoryModelExists(id))
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

        // POST: api/jobCatagoryModels
        [ResponseType(typeof(jobCatagoryModel))]
        public IHttpActionResult PostjobCatagoryModel(jobCatagoryModel jobCatagoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.jobCatagoryModels.Add(jobCatagoryModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jobCatagoryModel.Id }, jobCatagoryModel);
        }

        // DELETE: api/jobCatagoryModels/5
        [ResponseType(typeof(jobCatagoryModel))]
        public IHttpActionResult DeletejobCatagoryModel(int id)
        {
            jobCatagoryModel jobCatagoryModel = db.jobCatagoryModels.Find(id);
            if (jobCatagoryModel == null)
            {
                return NotFound();
            }

            db.jobCatagoryModels.Remove(jobCatagoryModel);
            db.SaveChanges();

            return Ok(jobCatagoryModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool jobCatagoryModelExists(int id)
        {
            return db.jobCatagoryModels.Count(e => e.Id == id) > 0;
        }
    }
}