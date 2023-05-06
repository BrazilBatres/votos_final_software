using votos_API.DataAccess.common;
using votos_API.DataAccess.interfaces;
using votos_API.DataAccess.models;
using votos_API.Models.candidato;

namespace votos_API.DataAccess.repositories
{
    public sealed class clsCandidatoRepository : ICandidatoRepository
    {
        private readonly EleccionesContext _context;

        public clsCandidatoRepository(EleccionesContext context)
        {
            _context = context;
        }
        public async Task addCandidato(clsNewCandidato newCandidato)
        {
            
            if (_context == null)
            {
                bool prueba = true;
            }
            Candidato voto = new Candidato()
            {
                Nombre = newCandidato.Nombre,
                Apellidos = newCandidato.Apellidos,
                FechaNacimiento = newCandidato.FechaNacimiento,
                FormacionProfesional = newCandidato.FormacionProfesional,
                Sexo = newCandidato.Sexo,
                PartidoPolitico = newCandidato.PartidoPolitico,
                Informacion = newCandidato.Informacion,
            };
            _context.Candidatos.Add(voto);
            await _context.SaveChangesAsync();
        }
    }
}
