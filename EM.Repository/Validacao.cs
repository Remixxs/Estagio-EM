using EM.Domain;
using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace EM.Repository
{
    public class Validacao
    {
        readonly RepositorioAluno repositorioAluno = new RepositorioAluno();
        public static Regex regexNome = new Regex("^[A-ZÀ-Ÿ][A-zÀ-ÿ']+\\s([A-zÀ-ÿ']\\s?)*[A-ZÀ-Ÿ][A-zÀ-ÿ']+$ | ^[A–Z][A–Za–z']+$", RegexOptions.IgnoreCase
        | RegexOptions.CultureInvariant
        | RegexOptions.IgnorePatternWhitespace
        | RegexOptions.Compiled
        );
        public static Regex regexCpf = new Regex("^[0-9]*$");
        public Boolean EhCpfValido(string cpf)
        {
            if (!string.IsNullOrWhiteSpace(cpf))
            {
                if (cpf.Length != 11)
                {
                    return false;
                }
                for (var i = 0; i < 11; i++)
                {
                    if (!char.IsDigit(cpf[i]))
                    {
                        return false;
                    }
                }
                var intCpf = new int[11];
                int soma = 0;
                for (int i = 0, j = 10; i < 11; i++, j--)
                {
                    var sucessoNaConversao = int.TryParse(cpf[i].ToString(), out var valor);
                    intCpf[i] = valor;
                    if (j >= 2 && sucessoNaConversao)
                    {
                        soma += intCpf[i] * j;
                    }
                }
                var cpfComTodosDigitosIguais = true;
                for (var i = 1; i < 11; i++)
                {
                    if (intCpf[0] != intCpf[i])
                    {
                        cpfComTodosDigitosIguais = false;
                        break;
                    }
                }
                if (cpfComTodosDigitosIguais)
                {
                    return false;
                }
                int penultimoDigito = (soma * 10) % 11;
                if (penultimoDigito == 10)
                {
                    penultimoDigito = 0;
                }
                if (penultimoDigito != intCpf[9])
                {
                    return false;
                }
                soma = 0;
                for (int i = 0, j = 11; j >= 2; i++, j--)
                {
                    soma += intCpf[i] * j;
                }
                int ultimoDigito = (soma * 10) % 11;
                if (ultimoDigito == 10)
                {
                    ultimoDigito = 0;
                }
                if (ultimoDigito != intCpf[10])
                {
                    return false;
                }
            }
            return true;
        }
        public Boolean EhCpfRepetido(Aluno aluno)
        {
            if (!string.IsNullOrEmpty(aluno.CPF) && repositorioAluno.GetAll().Any(alunoAdicionado => alunoAdicionado.CPF != null &&
                    alunoAdicionado.CPF.Equals(aluno.CPF) && !alunoAdicionado.Equals(aluno)))
            {
                return true;
            }
            return false;
        }
        public string ObtemMensagemCasoDataInvalida(DateTime dataNascimento)
        {
            if (dataNascimento.Equals(DateTime.MinValue))
            {
                return "Data não pode ser vazia &\nDeve seguir as regras de cada mês";
            }
            if(dataNascimento.Year < 1890 || dataNascimento > DateTime.Now)
            {
                return "Data deve ser menor que a atual e ano superior a 1890";
            }
            if(dataNascimento <= DateTime.Now && dataNascimento.Year >= 1890 && !string.IsNullOrWhiteSpace(dataNascimento.Day.ToString()) && !string.IsNullOrWhiteSpace(dataNascimento.Month.ToString()) && !string.IsNullOrWhiteSpace(dataNascimento.Year.ToString()) && 
                dataNascimento.Day <= DateTime.DaysInMonth(dataNascimento.Year, dataNascimento.Month))
            {
                return null;
            }
            return "Data inválida";
        }
        public Boolean EhNomeValido(string nome)
        {
            if(nome.Length <= 100 && !string.IsNullOrWhiteSpace(nome))
            {
                for (int i = 0; i < nome.Length; i++)
                {
                    if (!char.IsLetter(nome[i]) && !char.IsWhiteSpace(nome[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean EhMatriculaValida(int matricula)
        {
            return (matricula > 0 && matricula <= 999999999);
        }
        public Boolean EhMatriculaRepetida(string matricula)
        {
            int matriculaInt = Convert.ToInt32(matricula);
            if(repositorioAluno.GetByMatricula(matriculaInt) != null)
            {
                return true;
            }
            return false;
        }
        public bool EhDadosRepetidos(Aluno aluno)
        {
            Aluno alunoEditado = repositorioAluno.GetByMatricula((int)aluno.Matricula);
            return alunoEditado.Nome.Equals(aluno.Nome)
                   && alunoEditado.Sexo.Equals(aluno.Sexo)
                   && alunoEditado.Nascimento.Equals(aluno.Nascimento)
                   && (Equals(alunoEditado.CPF, aluno.CPF) || (string.IsNullOrEmpty(alunoEditado.CPF) && string.IsNullOrEmpty(aluno.CPF)));
        }
        public List<String> RetornaListaErrosVerificacaoAlunoAdicionar(Aluno aluno)
        {
            List<string> listaDeErros = new List<string>();
            if (EhCpfValido(aluno.CPF) == false)
            {
                listaDeErros.Add("CPF inválido");
            }
            if (EhCpfRepetido(aluno))
            {
                listaDeErros.Add("CPF está sendo utilizado por outro aluno");
            }
            if (EhMatriculaRepetida(aluno.Matricula.ToString()))
            {
                listaDeErros.Add("Matrícula está sendo utilizada por outro aluno");
            }
            if (EhMatriculaValida((int)aluno.Matricula) == false)
            {
                listaDeErros.Add("Insira uma matrícula entre 1 e 999999999");
            }
            if(EhNomeValido(aluno.Nome) == false)
            {
                listaDeErros.Add("Nome inválido");
            }
            else if (!EhCpfRepetido(aluno) && EhCpfValido(aluno.CPF) && !EhMatriculaRepetida(aluno.Matricula.ToString()) 
                     && EhMatriculaValida((int)aluno.Matricula) && EhNomeValido(aluno.Nome))
            {
                listaDeErros = null;
            }
            return listaDeErros;
        }
        public List<String> RetornaListaErrosVerificacaoAlunoModificar(Aluno aluno)
        {
            List<string> listaDeErros = new List<string>();
            if (EhCpfValido(aluno.CPF) == false)
            {
                listaDeErros.Add("CPF inválido");
            }
            if (EhCpfRepetido(aluno))
            {
                listaDeErros.Add("CPF está sendo utilizado por outro aluno");
            }
            if (EhNomeValido(aluno.Nome) == false)
            {
                listaDeErros.Add("Nome inválido");
            }
            if (EhDadosRepetidos(aluno))
            {
                listaDeErros.Add("Dados já inseridos");
            }
            else if(EhCpfValido(aluno.CPF) && !EhDadosRepetidos(aluno) && !EhCpfRepetido(aluno) && EhNomeValido(aluno.Nome))
            {
                listaDeErros = null;
            }
            return listaDeErros;
        }
    }
}