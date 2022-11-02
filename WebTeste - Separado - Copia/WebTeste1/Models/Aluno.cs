using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebTeste
{
    public class Aluno : IEntidade
    {
        [Required(ErrorMessage = "Insira a matrícula do aluno.", AllowEmptyStrings = false)]
        [Range(1, 999999999, ErrorMessage = "Matrícula deve estar entre 1 e 999999999.")]
        public int? Matricula { get; set; }

        [Required(ErrorMessage = "Insira nome do aluno.", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 1)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Selecione o sexo do aluno.", AllowEmptyStrings = false)]
        public EnumeradorSexo? Sexo { get; set; }

        [Required(ErrorMessage = "Insira a data de nascimento do aluno.", AllowEmptyStrings = false)]
        [DataType(DataType.Date, ErrorMessage = "Isto não é uma data.")]
        [Display(Name = "Data de nascimento")]
        [Range(typeof(DateTime), "01/01/1950", "01/01/2022", ErrorMessage = "O ano de nascimento do aluno deve ser pelo menos 1950 e no máximo 01/01/2022.")]
        public DateTime? Nascimento { get; set; }

        [StringLength(14, MinimumLength = 11, ErrorMessage = "CPF deve ter 11 dígitos.")]
        public string? CPF { get; set; }

        public override bool Equals(Object aluno)
        {
            return aluno is Aluno alunoComparado && Matricula.Equals(alunoComparado.Matricula);
        }
        public override int GetHashCode()
        {
            return (int)Matricula;
        }
        public override string ToString()
        {
            return $"Matrícula: {Matricula}\nNome: {Nome}\nSexo: {Sexo}\nNascimento: {Nascimento:dd/MM/yyyy}\nCPF: {CPF}";
        }
    }
}
