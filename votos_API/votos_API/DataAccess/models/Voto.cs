using System;
using System.Collections.Generic;
using votos_API.Models.voto;

namespace votos_API.DataAccess.models;

public partial class Voto
{
    public int Id { get; set; }

    public int CandidatoId { get; set; }

    public string Dpi { get; set; } = null!;

    public DateTime FechaHora { get; set; }

    public string IpOrigen { get; set; } = null!;

    public sbyte EsFraudulento { get; set; }
    public sbyte Nulo { get; set; }

    public virtual Candidato? Candidato { get; set; }
}
