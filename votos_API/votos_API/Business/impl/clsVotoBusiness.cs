using votos_API.Business.interfaces;
using votos_API.Models.voto;
using votos_API.DataAccess.interfaces;

namespace votos_API.Business.impl
{
    public class clsVotoBusiness : IVotoBusiness
    {
        internal readonly IVotoRepository VotoRepository;

        public clsVotoBusiness(IVotoRepository VotoRepository) => this.VotoRepository = VotoRepository;
        public async Task postVoto(clsNewVoto voto)
        {
            await VotoRepository.addVoto(voto).ConfigureAwait(false);
        }
    }
}
