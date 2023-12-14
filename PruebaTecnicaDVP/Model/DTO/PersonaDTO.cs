namespace PruebaTecnicaDVP.Model.DTO
{
    public class PersonaDTO
    {
        public required string Nombre { get; set; }

        public required string Apellidos { get; set; }

        public int NumeroIdentificacion { get; set; }

        public required string Email { get; set; }

        public int TipoIdentificacion { get; set; }

        public required string Usuario { get; set; }

        public required string Password { get; set; }
    }
}
