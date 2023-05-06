namespace votos_API.Models.voto
{
    public sealed class clsVoto
    {
        public int Id { get; set; }

        public int CandidatoId { get; set; }

        public string Dpi { get; set; } = null!;

        public DateTime FechaHora { get; set; }

        public string IpOrigen { get; set; } = null!;

        public sbyte EsFraudulento { get; set; }

        public sbyte Nulo { get; set; }
    }
}
