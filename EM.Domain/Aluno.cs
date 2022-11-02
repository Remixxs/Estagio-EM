using System;

namespace EM.Domain
{
    public class Aluno : IEntidade
    {
        public int? Matricula { get; set; }
        public string Nome { get; set; }
        public EnumeradorSexo Sexo { get; set; }
        public DateTime? Nascimento { get; set; }
        public string CPF { get; set; }
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