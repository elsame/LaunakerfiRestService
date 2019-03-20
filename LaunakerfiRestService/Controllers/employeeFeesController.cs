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
    public class employeeFeesController : ApiController
    {
        private SalarySystemDBContext db = new SalarySystemDBContext();

        // GET: api/employeeFees
        public IQueryable<employeeFeesModel> GetemployeeFees()
        {
            return db.employeeFees;
        }

        // GET: api/employeeFees/5
        [ResponseType(typeof(employeeFeesModel))]
        public IHttpActionResult GetemployeeFees(int id)
        {
            //employeeFeesModel employeeFees = db.employeeFees.Find(id);
            var employeeFees = db.employeeFees.Where(x => x.employeeModelId == id).First();
            if (employeeFees == null)
            {
                return NotFound();
            }

            return Ok(employeeFees);
        }

        // PUT: api/employeeFees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutemployeeFees(int id, employeeFeesModel employeeFees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeFees.Id)
            {
                return BadRequest();
            }

            db.Entry(employeeFees).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeFeesExists(id))
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

        // POST: api/employeeFees
        [ResponseType(typeof(employeeFeesModel))]
        public IHttpActionResult PostemployeeFees(employeeFeesModel employeeFees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.employeeFees.Add(employeeFees);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employeeFees.Id }, employeeFees);
        }

        // DELETE: api/employeeFees/5
        [ResponseType(typeof(employeeFeesModel))]
        public IHttpActionResult DeleteemployeeFees(int id)
        {
            employeeFeesModel employeeFees = db.employeeFees.Find(id);
            if (employeeFees == null)
            {
                return NotFound();
            }

            db.employeeFees.Remove(employeeFees);
            db.SaveChanges();

            return Ok(employeeFees);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool employeeFeesExists(int id)
        {
            return db.employeeFees.Count(e => e.Id == id) > 0;
        }
    }
}