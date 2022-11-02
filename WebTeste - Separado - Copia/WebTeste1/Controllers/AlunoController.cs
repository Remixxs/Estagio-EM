using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace WebTeste.Controllers
{
    public class AlunoController : Controller
    {
        private readonly RepositorioAluno repositorioAluno = new();
        // GET: Aluno
        public ActionResult Index(string searchString, string option)
        {
            var alunosLista = from aluno in repositorioAluno.GetAll()
                              select aluno;
            if (string.IsNullOrEmpty(option) && string.IsNullOrWhiteSpace(searchString))
            {
                return View(alunosLista);
            }
            if (string.IsNullOrEmpty(option) ^ string.IsNullOrWhiteSpace(searchString))
            {
                return View(alunosLista);
            }
            else if (option.Equals("Nome"))
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    alunosLista = alunosLista.Where(a => a.Nome.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));
                }
                return View(alunosLista);
            }
            else if(option.Equals("Matricula"))
            {
                if (!string.IsNullOrEmpty(searchString) && Regex.IsMatch(searchString, "^[0-9]*$"))
                {
                    alunosLista = alunosLista.Where(a => a.Matricula.Equals(Convert.ToInt32(searchString)));
                }
                else
                {
                    ViewBag.Message = "Insira apenas números para buscar por matrícula.";
                }
                return View(alunosLista);
            }
            else
            {
                return View(repositorioAluno.GetAll());
            }
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            List<SelectListItem> sex_items = new()
            {
                new SelectListItem() { Text = "Masculino", Value = "Masculino" },
                new SelectListItem() { Text = "Feminino", Value = "Feminino" }
            };
            ViewBag.Sexo = sex_items;

            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aluno aluno)
        {
            List<SelectListItem> sex_items = new()
            {
                new SelectListItem() { Text = "Masculino", Value = "Masculino" },
                new SelectListItem() { Text = "Feminino", Value = "Feminino" }
            };
            ViewBag.Sexo = sex_items;

            if (!string.IsNullOrWhiteSpace(aluno.CPF))
            {
                string novoCpf = Regex.Replace(aluno.CPF, "[^0-9]", "");
                if (novoCpf.Length != 11)
                {
                    ModelState.AddModelError("CPF", "O CPF deve conter 11 dígitos.");
                    return View(aluno);
                }
                for (var i = 0; i < 11; i++)
                {
                    if (!char.IsDigit(novoCpf[i]))
                    {
                        ModelState.AddModelError("CPF", "O CPF deve conter apenas dígitos.");
                    }
                }
                var intCpf = new int[11];
                int soma = 0;
                for (int i = 0, j = 10; i < 11; i++, j--)
                {
                    var sucessoNaConversao = int.TryParse(novoCpf[i].ToString(), out var valor);
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
                    ModelState.AddModelError("CPF", "CPF's com todos dígitos iguais são inválidos.");
                }
                int penultimoDigito = (soma * 10) % 11;
                if (penultimoDigito == 10)
                {
                    penultimoDigito = 0;
                }
                if (penultimoDigito != intCpf[9])
                {
                    ModelState.AddModelError("CPF", "O CPF inserido é inválido.");
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
                    ModelState.AddModelError("CPF", "O CPF inserido é inválido.");
                }
            }

            if (!string.IsNullOrEmpty(aluno.CPF) && repositorioAluno.GetAll().Any(alunoAdicionado => alunoAdicionado.CPF != null &&
                    alunoAdicionado.CPF.Equals(aluno.CPF) && !alunoAdicionado.Equals(aluno)))
            {
                ModelState.AddModelError("CPF", "CPF inserido já está sendo utilizado por outro aluno.");
            }
            if(!string.IsNullOrEmpty(aluno.Nascimento.ToString())){
#pragma warning disable CS8629 // Nullable value type may be null.
                if (aluno.Nascimento?.Day >= DateTime.DaysInMonth((int)(aluno.Nascimento?.Year), (int)(aluno.Nascimento?.Month)))
#pragma warning restore CS8629 // Nullable value type may be null.
                {
                    ModelState.AddModelError("Data de nascimento", "Dias devem seguir as regras de cada mês. Insira uma data válida.");
                }
            }            

            if(aluno.Matricula != null)
            {
                if (repositorioAluno.GetByMatricula((int)aluno.Matricula) != null)
                {
                    ModelState.AddModelError("Matricula", "Matrícula já está sendo utilizada por outro aluno.");
                }
                if (!Regex.IsMatch(aluno.Matricula.ToString(), "^[0-9]*$"))
                {
                    ModelState.AddModelError("Matricula", "Insira apenas números na matrícula.");
                }
            }

            if (ModelState.IsValid)
            {
                repositorioAluno.Add(aluno);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int matricula)
        {
            List<SelectListItem> sex_items = new()
            {
                new SelectListItem() { Text = "Masculino", Value = "Masculino" },
                new SelectListItem() { Text = "Feminino", Value = "Feminino" }
            };
            ViewBag.Sexo = sex_items;
            Aluno aluno = repositorioAluno.GetByMatricula(matricula);
            if(aluno == null)
            {
                ViewBag.Message = "Aluno não encontrado";
                return View();
            }
            return View(aluno);
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(include: "Matricula, Nome, Sexo, Nascimento, CPF")] Aluno aluno)
        {
            List<SelectListItem> sex_items = new()
            {
                new SelectListItem() { Text = "Masculino", Value = "Masculino" },
                new SelectListItem() { Text = "Feminino", Value = "Feminino" }
            };
            ViewBag.Sexo = sex_items;

            if (!string.IsNullOrWhiteSpace(aluno.CPF))
            {
                string novoCpf = Regex.Replace(aluno.CPF, "[^0-9]", "");
                if (novoCpf.Length != 11)
                {
                    ModelState.AddModelError("CPF", "O CPF deve conter 11 dígitos.");
                    return View(aluno);
                }
                for (var i = 0; i < 11; i++)
                {
                    if (!char.IsDigit(novoCpf[i]))
                    {
                        ModelState.AddModelError("CPF", "O CPF deve conter apenas dígitos.");
                    }
                }
                var intCpf = new int[11];
                int soma = 0;
                for (int i = 0, j = 10; i < 11; i++, j--)
                {
                    var sucessoNaConversao = int.TryParse(novoCpf[i].ToString(), out var valor);
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
                    ModelState.AddModelError("CPF", "CPF's com todos dígitos iguais são inválidos.");
                }
                int penultimoDigito = (soma * 10) % 11;
                if (penultimoDigito == 10)
                {
                    penultimoDigito = 0;
                }
                if (penultimoDigito != intCpf[9])
                {
                    ModelState.AddModelError("CPF", "O CPF inserido é inválido.");
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
                    ModelState.AddModelError("CPF", "O CPF inserido é inválido.");
                }
            }

            if (!string.IsNullOrEmpty(aluno.CPF) && repositorioAluno.GetAll().Any(alunoAdicionado => alunoAdicionado.CPF != null &&
                    alunoAdicionado.CPF.Equals(aluno.CPF) && !alunoAdicionado.Equals(aluno)))
            {
                ModelState.AddModelError("CPF", "CPF inserido já está sendo utilizado por outro aluno.");
            }

            if (!string.IsNullOrEmpty(aluno.Nascimento.ToString())) 
            {
                if (aluno.Nascimento?.Day >= DateTime.DaysInMonth((int)(aluno.Nascimento?.Year), (int)(aluno.Nascimento?.Month)))
                {
                    ModelState.AddModelError("Data de nascimento", "Dias devem seguir as regras de cada mês. Insira uma data válida.");
                }
            }

            if (ModelState.IsValid)
            {
                repositorioAluno.Update(aluno);
                return RedirectToAction("Index");
            }
            else
            {
                return View(aluno);
            }
        }
        // GET: Aluno/Delete/5
        public ActionResult Delete(int matricula)
        {
            Aluno aluno = repositorioAluno.GetByMatricula(matricula);
            return View(aluno);
        }
        //POST: Aluno/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([Bind(include: "Matricula, Nome, Sexo, Nascimento, CPF")] Aluno aluno)
        {
            Aluno alunoParaDeletar = repositorioAluno.GetByMatricula((int)aluno.Matricula);
            repositorioAluno.Remove(alunoParaDeletar);
            return RedirectToAction("Index");
        }
    }
}
