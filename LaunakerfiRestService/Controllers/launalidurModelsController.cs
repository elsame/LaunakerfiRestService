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
    public class launalidurModelsController : ApiController
    {
        private SalarySystemDBContext db = new SalarySystemDBContext();

        // GET: api/launalidurModels
        /* public IQueryable<launalidurModel> GetlaunalidurModels()
         {
             return db.launalidurModels;
         }*/

        /// <summary>
        /// Gets launalidur list
        /// </summary>
        /// <param name="fradrattur">true to get list of all fradrattur</param>
        /// <param name="aSedli">true to get list of all aSedli</param>
        [HttpGet]
        public IQueryable<launalidurModel> GetlaunalidurModels(bool? fradrattur, bool? aSedli)
        {
            if (aSedli != null && fradrattur != null)
                return db.launalidurModels.Where(x => x.asedli == aSedli && x.fradrattur == fradrattur);

            return db.launalidurModels;
        }

        /// <summary>
        /// Gets launalidur list
        /// </summary>
        /// <param name="fradrattur">true to get list of all fradrattur</param>
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IQueryable<launalidurModel> GetlaunalidurModels(bool? fradrattur)
        {
             return db.launalidurModels.Where(x => x.fradrattur == fradrattur);
        }

        [ResponseType(typeof(launalidurModel))]
        public IHttpActionResult GetlaunalidurModel(int id)
        {
            launalidurModel launalidurModel = db.launalidurModels.Find(id);
            if (launalidurModel == null)
            {
                return NotFound();
            }

            return Ok(launalidurModel);
        }

        // PUT: api/launalidurModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutlaunalidurModel(int id, launalidurModel launalidurModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != launalidurModel.Id)
            {
                return BadRequest();
            }

            db.Entry(launalidurModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!launalidurModelExists(id))
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

        // POST: api/launalidurModels
        [ResponseType(typeof(launalidurModel))]
        public IHttpActionResult PostlaunalidurModel(launalidurModel launalidurModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.launalidurModels.Add(launalidurModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = launalidurModel.Id }, launalidurModel);
        }

        // DELETE: api/launalidurModels/5
        [ResponseType(typeof(launalidurModel))]
        public IHttpActionResult DeletelaunalidurModel(int id)
        {
            launalidurModel launalidurModel = db.launalidurModels.Find(id);
            if (launalidurModel == null)
            {
                return NotFound();
            }

            db.launalidurModels.Remove(launalidurModel);
            db.SaveChanges();

            return Ok(launalidurModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool launalidurModelExists(int id)
        {
            return db.launalidurModels.Count(e => e.Id == id) > 0;
        }
    }
}