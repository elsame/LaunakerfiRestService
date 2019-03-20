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
    public class employeeSettingsModelsController : ApiController
    {
        private SalarySystemDBContext db = new SalarySystemDBContext();

        // GET: api/employeeSettingsModels
        public IQueryable<employeeSettingsModel> GetemployeeSettingsModels()
        {
            return db.employeeSettingsModels;
        }

        // GET: api/employeeSettingsModels/5
        [ResponseType(typeof(employeeSettingsModel))]
        public IHttpActionResult GetemployeeSettingsModel(int id)
        {
            // employeeSettingsModel employeeSettingsModel = db.employeeSettingsModels.Find(id);
            var employeeSettingsModel = db.employeeSettingsModels.Where(x => x.employeeModelId == id).First();

            if (employeeSettingsModel == null)
            {
                return NotFound();
            }

            return Ok(employeeSettingsModel);
        }

        // PUT: api/employeeSettingsModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutemployeeSettingsModel(int id, employeeSettingsModel employeeSettingsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeSettingsModel.Id)
            {
                return BadRequest();
            }

            db.Entry(employeeSettingsModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeSettingsModelExists(id))
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

        // POST: api/employeeSettingsModels
        /// <summary>
        /// Insert a new value in the list
        /// </summary>
        /// <param name="employeeSettingsModel">New value to be inserted</param>
        [ResponseType(typeof(employeeSettingsModel))]
        public IHttpActionResult PostemployeeSettingsModel(employeeSettingsModel employeeSettingsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.employeeSettingsModels.Add(employeeSettingsModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employeeSettingsModel.Id }, employeeSettingsModel);
        }

        // DELETE: api/employeeSettingsModels/5
        [ResponseType(typeof(employeeSettingsModel))]
        public IHttpActionResult DeleteemployeeSettingsModel(int id)
        {
            employeeSettingsModel employeeSettingsModel = db.employeeSettingsModels.Find(id);
            if (employeeSettingsModel == null)
            {
                return NotFound();
            }

            db.employeeSettingsModels.Remove(employeeSettingsModel);
            db.SaveChanges();

            return Ok(employeeSettingsModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool employeeSettingsModelExists(int id)
        {
            return db.employeeSettingsModels.Count(e => e.Id == id) > 0;
        }
    }
}