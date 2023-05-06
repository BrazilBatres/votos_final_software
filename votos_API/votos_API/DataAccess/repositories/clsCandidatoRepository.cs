using votos_API.DataAccess.common;
using votos_API.DataAccess.interfaces;
using votos_API.DataAccess.models;
using votos_API.Models.voto;

namespace votos_API.DataAccess.repositories
{
    public sealed class clsVotoRepository : IVotoRepository
    {
        private readonly EleccionesContext _context;

        public clsVotoRepository(EleccionesContext context)
        {
            _context = context;
        }
        public async Task addVoto(clsNewVoto newVoto)
        {
            
            if (_context == null)
            {
                bool prueba = true;
            }
            Voto voto = new Voto()
            {
                CandidatoId = newVoto.CandidatoId,
                Dpi = newVoto.Dpi,
                FechaHora = newVoto.FechaHora,
                IpOrigen = newVoto.IpOrigen,
                EsFraudulento = newVoto.EsFraudulento
            };
            _context.Votos.Add(voto);
            await _context.SaveChangesAsync();
        }
    }
}
