using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos
{
    public class CreateUsuarioDto
    {
        [Required]
        public string NomeDeUsuario { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required]
        [Compare("Senha")]
        public string ConfirmacaoDeSenha { get; set; }
    }
}
