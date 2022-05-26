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
using APIMussicCipher.Models;

namespace APIMussicCipher.Controllers
{
    public class MusicaCompletasController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/MusicaCompletas
        public IQueryable<MusicaCompleta> GetMusicaCompleta()
        {
            return db.MusicaCompleta;
        }

        // GET: api/MusicaCompletas/5
        [ResponseType(typeof(MusicaCompleta))]
        public IHttpActionResult GetMusicaCompleta(int id)
        {
            MusicaCompleta musicaCompleta = db.MusicaCompleta.Find(id);
            if (musicaCompleta == null)
            {
                return NotFound();
            }

            return Ok(musicaCompleta);
        }

        // PUT: api/MusicaCompletas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMusicaCompleta(int id, MusicaCompleta musicaCompleta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != musicaCompleta.Id)
            {
                return BadRequest();
            }

            db.Entry(musicaCompleta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicaCompletaExists(id))
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

        // POST: api/MusicaCompletas
        [ResponseType(typeof(MusicaCompleta))]
        public IHttpActionResult PostMusicaCompleta(MusicaCompleta musicaCompleta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MusicaCompleta.Add(musicaCompleta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = musicaCompleta.Id }, musicaCompleta);
        }

        // DELETE: api/MusicaCompletas/5
        [ResponseType(typeof(MusicaCompleta))]
        public IHttpActionResult DeleteMusicaCompleta(int id)
        {
            MusicaCompleta musicaCompleta = db.MusicaCompleta.Find(id);
            if (musicaCompleta == null)
            {
                return NotFound();
            }

            db.MusicaCompleta.Remove(musicaCompleta);
            db.SaveChanges();

            return Ok(musicaCompleta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MusicaCompletaExists(int id)
        {
            return db.MusicaCompleta.Count(e => e.Id == id) > 0;
        }
    }
}