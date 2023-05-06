using System;
using System.Collections.Generic;
using votos_API.Models.voto;

namespace votos_API.DataAccess.models;

public partial class Voto
{
    //public Voto(clsNewVoto newVoto) 
    //{
    //    this.Id = 0;
    //    this.CandidatoId = newVoto.CandidatoId;
    //    this.Dpi = newVoto.Dpi;
    //    this.FechaHora = newVoto.FechaHora;
    //    this.IpOrigen = newVoto.IpOrigen;
    //    this.EsFraudulento = newVoto.EsFraudulento;
    //}
    public int Id { get; set; }

    public int CandidatoId { get; set; }

    public string Dpi { get; set; } = null!;

    public DateTime FechaHora { get; set; }

    public string IpOrigen { get; set; } = null!;

    public sbyte EsFraudulento { get; set; }

    public virtual Candidato? Candidato { get; set; }
}
