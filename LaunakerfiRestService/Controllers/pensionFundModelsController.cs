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
    public class pensionFundModelsController : ApiController
    {
        private SalarySystemDBContext db = new SalarySystemDBContext();

        // GET: api/pensionFundModels
        public IQueryable<pensionFundModel> GetpensionFundModels()
        {
            return db.pensionFundModels;
        }

        // GET: api/pensionFundModels/5
        [ResponseType(typeof(pensionFundModel))]
        public IHttpActionResult GetpensionFundModel(int id)
        {
            pensionFundModel pensionFundModel = db.pensionFundModels.Find(id);
            if (pensionFundModel == null)
            {
                return NotFound();
            }

            return Ok(pensionFundModel);
        }

        // PUT: api/pensionFundModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutpensionFundModel(int id, pensionFundModel pensionFundModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pensionFundModel.Id)
            {
                return BadRequest();
            }

            db.Entry(pensionFundModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pensionFundModelExists(id))
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

        // POST: api/pensionFundModels
        [ResponseType(typeof(pensionFundModel))]
        public IHttpActionResult PostpensionFundModel(pensionFundModel pensionFundModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.pensionFundModels.Add(pensionFundModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pensionFundModel.Id }, pensionFundModel);
        }

        // DELETE: api/pensionFundModels/5
        [ResponseType(typeof(pensionFundModel))]
        public IHttpActionResult DeletepensionFundModel(int id)
        {
            pensionFundModel pensionFundModel = db.pensionFundModels.Find(id);
            if (pensionFundModel == null)
            {
                return NotFound();
            }

            db.pensionFundModels.Remove(pensionFundModel);
            db.SaveChanges();

            return Ok(pensionFundModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool pensionFundModelExists(int id)
        {
            return db.pensionFundModels.Count(e => e.Id == id) > 0;
        }
    }
}