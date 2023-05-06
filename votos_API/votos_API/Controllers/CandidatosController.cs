using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using votos_API.Business.interfaces;
using votos_API.DataAccess.models;
using votos_API.Models.candidato;
using votos_API.Models.voto;

namespace votos_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatosController : ControllerBase
    {

        public CandidatosController()
        {
        }

        

        
        

        // POST: api/Candidatoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //ADMINISTRATIVO
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Candidato>> PostCandidato(ICandidatoBusiness bs, clsNewCandidato newCandidato)
        {
            await bs.postCandidato(newCandidato).ConfigureAwait(false);
            return Ok(newCandidato);
        }
    }
}
