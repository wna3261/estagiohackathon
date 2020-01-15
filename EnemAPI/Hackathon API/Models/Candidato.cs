using System;
using System.ComponentModel.DataAnnotations;

namespace Hackathon_API.Models
{
    public class Candidato
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter no minimo 3 caracteres.")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Cidade é obrigatório.", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-z\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos na cidade.")]
        public string Cidade { get; set; }
        private double _nota;
        [Range(0, 100, ErrorMessage = "A nota deve estar entre 0 e 100")]
        [Required(ErrorMessage = "O campo Nota é obrigatório.")]
        //[RegularExpression(@"^[\d]+[,]?[\d]{0,2}?$", ErrorMessage = "A nota so pode ter 2 casas depois da virgula")]
        public double Nota
        {
            get => _nota;
            set => _nota = Math.Round(value, 2);
        }

        public bool Situacao { get; set; }
    }
}