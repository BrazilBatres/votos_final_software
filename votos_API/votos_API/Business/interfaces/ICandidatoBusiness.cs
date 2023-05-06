using votos_API.Models.candidato;

namespace votos_API.Business.interfaces
{
    public interface ICandidatoBusiness
    {
        Task postCandidato(clsNewCandidato candidato);
    }
}

