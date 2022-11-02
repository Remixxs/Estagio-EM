using EM.Domain;
using EM.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EM.WindowsForms
{
    public partial class CadastroAluno : Form
    {
        public CadastroAluno()
        {
            InitializeComponent();
            RepositorioAluno repositorioAluno = new RepositorioAluno();
            try
            {
                bindingSource1.DataSource = repositorioAluno.GetAll().ToSortableBindingList();
                dataGridView1.DataSource = bindingSource1;

                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Width = 350;
                dataGridView1.Columns[2].Width = 55;
                dataGridView1.Columns[3].Width = 95;
                dataGridView1.Columns[4].Width = 90;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao carregar o banco de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AlteraBotoes(string modo)
        {
            if (modo == "ModoModificar")
            {
                txtMatricula.ReadOnly = true;
                btnAdicionar.Text = "Modificar";
                btnLimpar.Text = "Cancelar";
                NovoEditandoBox.Text = "Editando aluno";
            }
            else if (modo == "ModoAdicionar")
            {
                txtMatricula.ReadOnly = false;
                btnAdicionar.Text = "Adicionar";
                btnLimpar.Text = "Limpar";
                NovoEditandoBox.Text = "Novo aluno";
            }
        }
        public Aluno PreencheCamposComGrid()
        {
            Aluno aluno = (Aluno)bindingSource1.Current;
            if (aluno != null)
            {
                txtMatricula.Text = aluno.Matricula.ToString();
                txtNome.Text = aluno.Nome;
                txtNascimento.Text = aluno.Nascimento.ToString();
                txtCPF.Text = aluno.CPF.ToString();
                if (aluno.Sexo == EnumeradorSexo.Masculino)
                {
                    comboSexo.SelectedIndex = 1;
                }
                else
                {
                    comboSexo.SelectedIndex = 0;
                }
            }
            return aluno;
        }
        public void LimpaCampos()
        {
            txtMatricula.Clear();
            txtNome.Clear();
            txtNascimento.Clear();
            txtCPF.Clear();
            txtBarraDePesquisa.Clear();
            comboSexo.SelectedIndex = -1;
        }
        private void AdicionarOuModificarBtn_Click(object sender, EventArgs e)
        {
            Validacao validacoes = new Validacao();
            RepositorioAluno repositorioAluno = new RepositorioAluno();
            List<string> erros;
            if (btnAdicionar.Text == "Adicionar")
            {
                if (string.IsNullOrWhiteSpace(txtMatricula.Text) || string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrWhiteSpace(txtNascimento.Text) || (comboSexo.SelectedIndex != 1 && comboSexo.SelectedIndex != 0))
                {
                    MessageBox.Show("Preencha todos os campos obrigatórios! Indicados por (*)", "Campo(s) vazio(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (string.IsNullOrWhiteSpace(txtMatricula.Text))
                    {
                        txtMatricula.Focus();
                    }
                    else if (string.IsNullOrEmpty(txtNome.Text))
                    {
                        txtNome.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(txtNascimento.Text))
                    {
                        txtNascimento.Focus();
                    }
                    else if (comboSexo.SelectedIndex != 1 && comboSexo.SelectedIndex != 0)
                    {
                        comboSexo.Focus();
                    }
                }
                else
                {
                    Aluno alunoAdicionar = new Aluno();
                    string dataErrada = null;
                    alunoAdicionar.Nome = txtNome.Text.TrimStart().TrimEnd();
                    alunoAdicionar.Matricula = Convert.ToInt32(txtMatricula.Text);
                    if (!string.IsNullOrWhiteSpace(txtNascimento.Text))
                    {
                        DateTime.TryParseExact(txtNascimento.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime nascimento);
                        dataErrada = validacoes.ObtemMensagemCasoDataInvalida(nascimento);
                        if (dataErrada == null)
                        {
                            alunoAdicionar.Nascimento = nascimento;
                        }
                        else
                        {
                            txtNascimento.Focus();
                            MessageBox.Show(dataErrada, "Data de nascimento inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (string.IsNullOrWhiteSpace(txtCPF.Text))
                    {
                        alunoAdicionar.CPF = null;
                    }
                    else
                    {
                        alunoAdicionar.CPF = txtCPF.Text;
                    }
                    if (comboSexo.SelectedIndex == 1)
                    {
                        alunoAdicionar.Sexo = EnumeradorSexo.Masculino;
                    }
                    else
                    {
                        alunoAdicionar.Sexo = EnumeradorSexo.Feminino;
                    }
                    erros = validacoes.RetornaListaErrosVerificacaoAlunoAdicionar(alunoAdicionar);
                    if (erros == null && dataErrada == null)
                    {
                        repositorioAluno.Add(alunoAdicionar);
                        LimpaCampos();
                    }
                    else if (erros != null)
                    {
                        MessageBox.Show(String.Join("\n", erros), $"Erro ao adicionar aluno {alunoAdicionar.Matricula}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    bindingSource1.DataSource = repositorioAluno.GetAll().ToSortableBindingList();
                }
            }
            else
            {
                if (!dataGridView1.SelectedRows[0].IsNewRow)
                {
                    if (string.IsNullOrWhiteSpace(txtMatricula.Text) || string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrWhiteSpace(txtNascimento.Text) || (comboSexo.SelectedIndex != 1 && comboSexo.SelectedIndex != 0))
                    {
                        MessageBox.Show("Preencha todos os campos obrigatórios! Indicados por (*)", "Campo(s) vazio(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (string.IsNullOrWhiteSpace(txtMatricula.Text))
                        {
                            txtMatricula.Focus();
                        }
                        else if (string.IsNullOrEmpty(txtNome.Text))
                        {
                            txtNome.Focus();
                        }
                        else if (string.IsNullOrWhiteSpace(txtNascimento.Text))
                        {
                            txtNascimento.Focus();
                        }
                        else if (comboSexo.SelectedIndex != 1 && comboSexo.SelectedIndex != 0)
                        {
                            comboSexo.Focus();
                        }
                    }
                    else
                    {
                        Aluno alunoModificar = new Aluno();
                        string dataErrada = null;
                        alunoModificar.Matricula = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
                        alunoModificar.Nome = txtNome.Text.TrimStart().TrimEnd();

                        if (!string.IsNullOrWhiteSpace(txtNascimento.Text))
                        {
                            DateTime.TryParse(txtNascimento.Text, out DateTime nascimento);
                            dataErrada = validacoes.ObtemMensagemCasoDataInvalida(nascimento);
                            if (dataErrada == null)
                            {
                                alunoModificar.Nascimento = nascimento;
                            }
                            else
                            {
                                txtNascimento.Focus();
                                MessageBox.Show(dataErrada, "Data de nascimento inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        if (string.IsNullOrWhiteSpace(txtCPF.Text))
                        {
                            alunoModificar.CPF = null;
                        }
                        else
                        {
                            alunoModificar.CPF = txtCPF.Text;
                        }
                        if (comboSexo.SelectedIndex == 1)
                        {
                            alunoModificar.Sexo = EnumeradorSexo.Masculino;
                        }
                        else
                        {
                            alunoModificar.Sexo = EnumeradorSexo.Feminino;
                        }
                        erros = validacoes.RetornaListaErrosVerificacaoAlunoModificar(alunoModificar);
                        if (erros == null && dataErrada == null)
                        {
                            repositorioAluno.Update(alunoModificar);
                            LimpaCampos();
                            AlteraBotoes("ModoAdicionar");
                            bindingSource1.DataSource = repositorioAluno.GetAll().ToSortableBindingList();
                        }
                        else if (erros != null)
                        {
                            MessageBox.Show(String.Join("\n", erros), $"Erro ao modificar aluno {alunoModificar.Matricula}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void ExcluirBtn_Click(object sender, EventArgs e)
        {
            if (!dataGridView1.SelectedRows[0].IsNewRow)
            {
                Aluno aluno = PreencheCamposComGrid();
                var result = MessageBox.Show($"Tem certeza que deseja excluir essa linha?\n\n{aluno}", $"Deletar aluno {aluno.Matricula}?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    RepositorioAluno repositorioAluno = new RepositorioAluno();
                    repositorioAluno.Remove(aluno);
                    bindingSource1.DataSource = repositorioAluno.GetAll().ToSortableBindingList(); dataGridView1.DataSource = bindingSource1;
                    LimpaCampos();
                    if (btnLimpar.Text == "Cancelar")
                    {
                        AlteraBotoes("ModoAdicionar");
                    }
                }
            }
        }
        private void EditarBtn_Click(object sender, EventArgs e)
        {
            AlteraBotoes("ModoModificar");

            if (!dataGridView1.SelectedRows[0].IsNewRow)
            {
                PreencheCamposComGrid();
            }
            else
            {
                MessageBox.Show("Nenhum aluno disponível para editar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimparOuCancelarBtn_Click(object sender, EventArgs e)
        {
            if (btnLimpar.Text == "Limpar")
            {
                LimpaCampos();
            }
            else
            {
                AlteraBotoes("ModoAdicionar");
                LimpaCampos();
            }
        }
        private void PesquisaBox_Click(object sender, EventArgs e)
        {
            RepositorioAluno repositorioAluno = new RepositorioAluno();
            Validacao validacao = new Validacao();
            if (int.TryParse(txtBarraDePesquisa.Text, out int matricula))
            {
                List<Aluno> alunos = new List<Aluno>()
                {
                    repositorioAluno.GetByMatricula(matricula)
                };
                if (repositorioAluno.GetByMatricula(matricula) is null)
                {
                    bindingSource1.DataSource = null;
                    MessageBox.Show("Nenhum aluno encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bindingSource1.DataSource = alunos.ToSortableBindingList();
                }
            }
            else if (string.IsNullOrEmpty(txtBarraDePesquisa.Text))
            {
                bindingSource1.DataSource = repositorioAluno.GetAll().ToSortableBindingList();
            }
            else if (validacao.EhNomeValido(txtBarraDePesquisa.Text.ToLowerInvariant()) == true)
            {
                bindingSource1.DataSource = repositorioAluno.GetByContendoNoNome(txtBarraDePesquisa.Text).ToSortableBindingList();
            }
            else
            {
                bindingSource1.DataSource = null;
                MessageBox.Show("Nenhum aluno encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BarraDePesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PesquisaBox_Click(sender, e);
            }
        }
        private void MatriculaBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (char)Keys.Back != e.KeyChar)
            {
                e.Handled = true;
            }
        }
        private void CpfBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (char)Keys.Back != e.KeyChar)
            {
                e.Handled = true;
            }
        }
        private void NomeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && (char)Keys.Back != e.KeyChar)
            {
                e.Handled = true;
            }
        }
        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    ExcluirBtn_Click(sender, e);
                }
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                if (e.KeyCode == Keys.Enter)
                    e.Handled = true;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    EditarBtn_Click(sender, e);
                }
            }
        }
        private void DataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                EditarBtn_Click(sender, e);
            }
        }
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && !string.IsNullOrWhiteSpace(e.Value.ToString()))
            {
                string CPFDividido = e.Value.ToString();
                string CPF = CPFDividido.Insert(9, "-").Insert(6, ".").Insert(3, ".");
                e.Value = CPF;
                e.FormattingApplied = true;
            }
        }
    }
}