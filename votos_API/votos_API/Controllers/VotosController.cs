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
        

        // POST: api/Votoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //PÚBLICO
        public async Task<ActionResult<string>> PostVoto(IVotoBusiness bs, clsNewVoto newVoto)
        {
            await bs.postVoto(newVoto).ConfigureAwait(false);
            return Ok(newVoto);
        }

        
    }
}
