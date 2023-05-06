namespace votos_API.Models.voto
{
    public sealed class clsNewVoto
    {
        public int CandidatoId { get; set; }

        public string Dpi { get; set; } = null!;

        public DateTime FechaHora { get; set; }

        public string IpOrigen { get; set; } = null!;

        public sbyte EsFraudulento { get; set; }
    }
}
