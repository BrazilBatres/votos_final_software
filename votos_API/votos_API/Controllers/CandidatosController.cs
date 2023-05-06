using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using votos_API.Business.interfaces;
using votos_API.DataAccess.common;
using votos_API.DataAccess.models;
using votos_API.Models.candidato;
using votos_API.Models.voto;

namespace votos_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatosController : ControllerBase
    {
        private readonly EleccionesContext _context;

        public CandidatosController()
        {
            _context = new EleccionesContext();
        }

        // GET: api/Candidatoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidato>>> GetCandidatos()
        {
          if (_context.Candidatos == null)
          {
              return NotFound();
          }
            return await _context.Candidatos.ToListAsync();
        }

        // GET: api/Candidatoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidato>> GetCandidato(int id)
        {
          if (_context.Candidatos == null)
          {
              return NotFound();
          }
            var candidato = await _context.Candidatos.FindAsync(id);

            if (candidato == null)
            {
                return NotFound();
            }

            return candidato;
        }

        // PUT: api/Candidatoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidato(int id, Candidato candidato)
        {
            if (id != candidato.Id)
            {
                return BadRequest();
            }

            _context.Entry(candidato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Candidatoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Candidato>> PostCandidato(ICandidatoBusiness bs, clsNewCandidato newCandidato)
        {
            await bs.postCandidato(newCandidato).ConfigureAwait(false);
            return Ok(newCandidato);
        }

        // DELETE: api/Candidatoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidato(int id)
        {
            if (_context.Candidatos == null)
            {
                return NotFound();
            }
            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }

            _context.Candidatos.Remove(candidato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandidatoExists(int id)
        {
            return (_context.Candidatos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
