using votos_API.DataAccess.models;
using votos_API.Models.voto;
namespace votos_API.DataAccess.interfaces
{
    public interface IVotoRepository
    {
        Task addVoto(clsNewVoto newVoto);
    }
}
