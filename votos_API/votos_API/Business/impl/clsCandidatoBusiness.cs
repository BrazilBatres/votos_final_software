using votos_API.Business.interfaces;
using votos_API.Models.candidato;
using votos_API.DataAccess.interfaces;

namespace votos_API.Business.impl
{
    public class clsCandidatoBusiness : ICandidatoBusiness
    {
        internal readonly ICandidatoRepository CandidatoRepository;

        public clsCandidatoBusiness(ICandidatoRepository CandidatoRepository) => this.CandidatoRepository = CandidatoRepository;
        public async Task postCandidato(clsNewCandidato voto)
        {
            await CandidatoRepository.addCandidato(voto).ConfigureAwait(false);
        }
    }
}
