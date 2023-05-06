using votos_API.DataAccess.models;
using votos_API.Models.candidato;
namespace votos_API.DataAccess.interfaces
{
    public interface ICandidatoRepository
    {
        Task addCandidato(clsNewCandidato newCandidato);
    }
}
