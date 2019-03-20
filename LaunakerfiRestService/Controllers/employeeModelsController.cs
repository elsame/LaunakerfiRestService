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
    public class employeeModelsController : ApiController
    {
        private SalarySystemDBContext db = new SalarySystemDBContext();

        // GET: api/employeeModels
        /// <summary>
        /// Retrieves the list of employees
        /// </summary>
        /// <returns></returns>
        public IQueryable<employeeModel> GetEmployee()
        {
            return db.Employee;
        }

        // GET: api/employeeModels/5
        /// <summary>
        /// Retrieves one value from the list of employees
        /// </summary>
        /// <param name="id">The id of the item to be retrieved</param>
        /// <returns></returns>
        [ResponseType(typeof(employeeModel))]
        public IHttpActionResult GetemployeeModel(int id)
        {
            employeeModel employeeModel = db.Employee.Find(id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            return Ok(employeeModel);
        }

        // PUT: api/employeeModels/5
        /// <summary>
        /// Change a single value in the list
        /// </summary>
        /// <param name="id">The id of the value to be changed</param>
        /// <param name="employeeModel">The new value</param>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutemployeeModel(int id, employeeModel employeeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeModel.Id)
            {
                return BadRequest();
            }

            db.Entry(employeeModel).State = EntityState.Modified;

            try
            {

                db.SaveChanges();


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeModelExists(id))
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

        // POST: api/employeeModels
        /// <summary>
        /// Insert a new value in the list
        /// </summary>
        /// <param name="employeeModel">New value to be inserted</param>
        [ResponseType(typeof(employeeModel))]
        public IHttpActionResult PostemployeeModel(employeeModel employeeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employee.Add(employeeModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employeeModel.Id }, employeeModel);
        }

        // DELETE: api/employeeModels/5
        [ResponseType(typeof(employeeModel))]
        public IHttpActionResult DeleteemployeeModel(int id)
        {
            employeeModel employeeModel = db.Employee.Find(id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            db.Employee.Remove(employeeModel);
            db.SaveChanges();

            return Ok(employeeModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool employeeModelExists(int id)
        {
            return db.Employee.Count(e => e.Id == id) > 0;
        }
    }
}