using System.ComponentModel.DataAnnotations;

namespace Turma.Models
{
    public class DadosCadastro
    {
        [Required(ErrorMessage = "O nome é obrigatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome deve no minimo 3 caracteres e no maximo 50.")]
        public string nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatorio.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string email {get; set; } = string.Empty;

        [Required(ErrorMessage = "O numero da turma é obrigatorio")]
        [Range(1, 8, ErrorMessage = "O numero deve ser entre 1 e 8")]
        public int turma { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatoria")]
        [MaxLength(500, ErrorMessage = "A desrição é no maximo de 500 caracteres")]
        public string descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O numero do canditado é obrigatorio")]
        [Range(10, 99, ErrorMessage = "O numero do canditado é de 10 a 99")]
        public int numeroCandidado { get; set; }
    }
}