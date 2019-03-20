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
    public class unionModelsController : ApiController
    {
        private SalarySystemDBContext db = new SalarySystemDBContext();

        // GET: api/unionsModels
        public IQueryable<unionModel> GetunionsModels()
        {
            return db.unionsModels;
        }

        // GET: api/unionsModels/5
        [ResponseType(typeof(unionModel))]
        public IHttpActionResult GetunionsModel(int id)
        {
            unionModel unionsModel = db.unionsModels.Find(id);
            if (unionsModel == null)
            {
                return NotFound();
            }

            return Ok(unionsModel);
        }

        // PUT: api/unionsModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutunionsModel(int id, unionModel unionsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unionsModel.Id)
            {
                return BadRequest();
            }

            db.Entry(unionsModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!unionsModelExists(id))
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

        // POST: api/unionsModels
        [ResponseType(typeof(unionModel))]
        public IHttpActionResult PostunionsModel(unionModel unionsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.unionsModels.Add(unionsModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = unionsModel.Id }, unionsModel);
        }

        // DELETE: api/unionsModels/5
        [ResponseType(typeof(unionModel))]
        public IHttpActionResult DeleteunionsModel(int id)
        {
            unionModel unionsModel = db.unionsModels.Find(id);
            if (unionsModel == null)
            {
                return NotFound();
            }

            db.unionsModels.Remove(unionsModel);
            db.SaveChanges();

            return Ok(unionsModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool unionsModelExists(int id)
        {
            return db.unionsModels.Count(e => e.Id == id) > 0;
        }
    }
}