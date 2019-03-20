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
    public class companyModelsController : ApiController
    {
        private SalarySystemDBContext db = new SalarySystemDBContext();

        // GET: api/companyModels
        public IQueryable<companyModel> GetCompany()
        {
            return db.Company;
        }

        // GET: api/companyModels/5
        [ResponseType(typeof(companyModel))]
        public IHttpActionResult GetcompanyModel(int id)
        {
            companyModel companyModel = db.Company.Find(id);
            if (companyModel == null)
            {
                return NotFound();
            }

            return Ok(companyModel);
        }

        // PUT: api/companyModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutcompanyModel(int id, companyModel companyModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyModel.Id)
            {
                return BadRequest();
            }

            db.Entry(companyModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!companyModelExists(id))
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

        // POST: api/companyModels
        [ResponseType(typeof(companyModel))]
        public IHttpActionResult PostcompanyModel(companyModel companyModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Company.Add(companyModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = companyModel.Id }, companyModel);
        }

        // DELETE: api/companyModels/5
        [ResponseType(typeof(companyModel))]
        public IHttpActionResult DeletecompanyModel(int id)
        {
            companyModel companyModel = db.Company.Find(id);
            if (companyModel == null)
            {
                return NotFound();
            }

            db.Company.Remove(companyModel);
            db.SaveChanges();

            return Ok(companyModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool companyModelExists(int id)
        {
            return db.Company.Count(e => e.Id == id) > 0;
        }
    }
}