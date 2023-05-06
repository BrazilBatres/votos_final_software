using votos_API.Models.voto;

namespace votos_API.Business.interfaces
{
    public interface IVotoBusiness
    {
        Task postVoto(clsNewVoto voto);
    }
}

