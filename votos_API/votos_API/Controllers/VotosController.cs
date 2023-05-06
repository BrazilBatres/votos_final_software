using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using votos_API.DataAccess.common;
using votos_API.DataAccess.models;
using votos_API.Business.interfaces;
using votos_API.Models.voto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace votos_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotosController : ControllerBase
    {
        private readonly EleccionesContext _context;

        public VotosController()
        {
            _context = new EleccionesContext();
        }

        // GET: api/Votoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voto>>> GetVotos()
        {
          if (_context.Votos == null)
          {
              return NotFound();
          }
            return await _context.Votos.ToListAsync();
        }

        // GET: api/Votoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voto>> GetVoto(int id)
        {
          if (_context.Votos == null)
          {
              return NotFound();
          }
            var voto = await _context.Votos.FindAsync(id);

            if (voto == null)
            {
                return NotFound();
            }

            return voto;
        }

        // PUT: api/Votoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoto(int id, Voto voto)
        {
            if (id != voto.Id)
            {
                return BadRequest();
            }

            _context.Entry(voto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VotoExists(id))
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

        // POST: api/Votoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<string>> PostVoto(IVotoBusiness bs, clsNewVoto newVoto)
        {
            await bs.postVoto(newVoto).ConfigureAwait(false);
            return Ok(newVoto);
        }

        // DELETE: api/Votoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoto(int id)
        {
            if (_context.Votos == null)
            {
                return NotFound();
            }
            var voto = await _context.Votos.FindAsync(id);
            if (voto == null)
            {
                return NotFound();
            }

            _context.Votos.Remove(voto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VotoExists(int id)
        {
            return (_context.Votos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
