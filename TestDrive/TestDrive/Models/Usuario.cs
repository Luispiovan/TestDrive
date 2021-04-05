namespace TestDrive.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string dataNasc { get; set; }
        public string telefone { get; set; }
    }

    public class ResultadoLogin
    {
        public Usuario usuario { get; set; }
    }
}