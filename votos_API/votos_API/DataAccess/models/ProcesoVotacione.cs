using System;
using System.Collections.Generic;

namespace votos_API.DataAccess.models;

public partial class ProcesoVotacione
{
    public int Id { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }
}
