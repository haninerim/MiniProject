using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MiniProject.Models;

namespace MiniProject.Controllers
{
    public class EtablissementsController : ApiController
    {
        private MiniProjectContext db = new MiniProjectContext();

        // GET: api/Etablissements
        public IQueryable<Etablissement> GetEtablissements()
        {
            return db.Etablissements;
        }

        // GET: api/Etablissements/5
        [ResponseType(typeof(Etablissement))]
        public async Task<IHttpActionResult> GetEtablissement(string id)
        {
            Etablissement etablissement = await db.Etablissements.FindAsync(id);
            if (etablissement == null)
            {
                return NotFound();
            }

            return Ok(etablissement);
        }

        // PUT: api/Etablissements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEtablissement(string id, Etablissement etablissement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != etablissement.NameEtabli)
            {
                return BadRequest();
            }

            db.Entry(etablissement).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtablissementExists(id))
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

        // POST: api/Etablissements
        [ResponseType(typeof(Etablissement))]
        public async Task<IHttpActionResult> PostEtablissement(Etablissement etablissement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Etablissements.Add(etablissement);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EtablissementExists(etablissement.NameEtabli))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = etablissement.NameEtabli }, etablissement);
        }

        // DELETE: api/Etablissements/5
        [ResponseType(typeof(Etablissement))]
        public async Task<IHttpActionResult> DeleteEtablissement(string id)
        {
            Etablissement etablissement = await db.Etablissements.FindAsync(id);
            if (etablissement == null)
            {
                return NotFound();
            }

            db.Etablissements.Remove(etablissement);
            await db.SaveChangesAsync();

            return Ok(etablissement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EtablissementExists(string id)
        {
            return db.Etablissements.Count(e => e.NameEtabli == id) > 0;
        }
    }
}