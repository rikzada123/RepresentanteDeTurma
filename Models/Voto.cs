using System.ComponentModel.DataAnnotations;
using Turma.Models.Validations;

namespace Turma.Models
{
    public class Voto
    {
        [Required(ErrorMessage = "O RA é obrigatório.")]
        [RaValidation(ErrorMessage = "O RA deve ter 6 digitos e ser apenas numeros.")]
        public string ra { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        public DateOnly dataVoto { get; set; }

        [Required(ErrorMessage = "O numero do canditado é obrigatorio")]
        [Range(10, 99, ErrorMessage = "O numero do canditado é de 10 a 99")]
        public int numeroCanditado { get; set; }
    }
}