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
using API.Models;

namespace API.Controllers
{
    public class ZapatosController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Zapatos
        public IQueryable<Zapatos> GetZapatos()
        {
            return db.Zapatos;
        }

        // GET: api/Zapatos/5
        [ResponseType(typeof(Zapatos))]
        public IHttpActionResult GetZapatos(int id)
        {
            Zapatos zapatos = db.Zapatos.Find(id);
            if (zapatos == null)
            {
                return NotFound();
            }

            return Ok(zapatos);
        }

        // PUT: api/Zapatos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZapatos(int id, Zapatos zapatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zapatos.IdZapatos)
            {
                return BadRequest();
            }

            db.Entry(zapatos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZapatosExists(id))
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

        // POST: api/Zapatos
        [ResponseType(typeof(Zapatos))]
        public IHttpActionResult PostZapatos(Zapatos zapatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zapatos.Add(zapatos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = zapatos.IdZapatos }, zapatos);
        }

        // DELETE: api/Zapatos/5
        [ResponseType(typeof(Zapatos))]
        public IHttpActionResult DeleteZapatos(int id)
        {
            Zapatos zapatos = db.Zapatos.Find(id);
            if (zapatos == null)
            {
                return NotFound();
            }

            db.Zapatos.Remove(zapatos);
            db.SaveChanges();

            return Ok(zapatos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZapatosExists(int id)
        {
            return db.Zapatos.Count(e => e.IdZapatos == id) > 0;
        }
    }
}