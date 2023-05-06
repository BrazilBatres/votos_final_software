namespace votos_API.Models.candidato
{
    public sealed class clsNewCandidato
    {
        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public DateTime FechaNacimiento { get; set; }

        public string FormacionProfesional { get; set; } = null!;

        public string Sexo { get; set; } = null!;

        public string PartidoPolitico { get; set; } = null!;

        public string? Informacion { get; set; }
    }
}
