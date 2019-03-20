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
    public class groupModelsController : ApiController
    {
        private SalarySystemDBContext db = new SalarySystemDBContext();

        // GET: api/groupModels
        public IQueryable<groupModel> GetgroupModels()
        {
            return db.groupModels;
        }

        // GET: api/groupModels/5
        [ResponseType(typeof(groupModel))]
        public IHttpActionResult GetgroupModel(int id)
        {
            groupModel groupModel = db.groupModels.Find(id);
            if (groupModel == null)
            {
                return NotFound();
            }

            return Ok(groupModel);
        }

        // PUT: api/groupModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutgroupModel(int id, groupModel groupModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupModel.Id)
            {
                return BadRequest();
            }

            db.Entry(groupModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!groupModelExists(id))
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

        // POST: api/groupModels
        [ResponseType(typeof(groupModel))]
        public IHttpActionResult PostgroupModel(groupModel groupModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.groupModels.Add(groupModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = groupModel.Id }, groupModel);
        }

        // DELETE: api/groupModels/5
        [ResponseType(typeof(groupModel))]
        public IHttpActionResult DeletegroupModel(int id)
        {
            groupModel groupModel = db.groupModels.Find(id);
            if (groupModel == null)
            {
                return NotFound();
            }

            db.groupModels.Remove(groupModel);
            db.SaveChanges();

            return Ok(groupModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool groupModelExists(int id)
        {
            return db.groupModels.Count(e => e.Id == id) > 0;
        }
    }
}