﻿using System;
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
    public class EtudiantsController : ApiController
    {
        private MiniProjectContext db = new MiniProjectContext();

        // GET: api/Etudiants
        public IQueryable<Etudiant> GetEtudiants()
        {
            return db.Etudiants;
        }

        // GET: api/Etudiants/5
        [ResponseType(typeof(Etudiant))]
        public async Task<IHttpActionResult> GetEtudiant(int id)
        {
            Etudiant etudiant = await db.Etudiants.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return Ok(etudiant);
        }

        // PUT: api/Etudiants/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEtudiant(int id, Etudiant etudiant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != etudiant.Id)
            {
                return BadRequest();
            }

            db.Entry(etudiant).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantExists(id))
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

        // POST: api/Etudiants
        [ResponseType(typeof(Etudiant))]
        public async Task<IHttpActionResult> PostEtudiant(Etudiant etudiant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Etudiants.Add(etudiant);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = etudiant.Id }, etudiant);
        }

        // DELETE: api/Etudiants/5
        [ResponseType(typeof(Etudiant))]
        public async Task<IHttpActionResult> DeleteEtudiant(int id)
        {
            Etudiant etudiant = await db.Etudiants.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }

            db.Etudiants.Remove(etudiant);
            await db.SaveChangesAsync();

            return Ok(etudiant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EtudiantExists(int id)
        {
            return db.Etudiants.Count(e => e.Id == id) > 0;
        }
    }
}