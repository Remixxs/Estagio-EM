namespace EM.WindowsForms
{
    partial class CadastroAluno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroAluno));
            this.txtNascimento = new System.Windows.Forms.MaskedTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.comboSexo = new System.Windows.Forms.ComboBox();
            this.NovoEditandoBox = new System.Windows.Forms.GroupBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.NomeLabel = new System.Windows.Forms.Label();
            this.MatriculaLabel = new System.Windows.Forms.Label();
            this.SexoLabel = new System.Windows.Forms.Label();
            this.NascimentoLabel = new System.Windows.Forms.Label();
            this.CPFLabel = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.txtBarraDePesquisa = new System.Windows.Forms.TextBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.groupBoxPesquisaAndGrid = new System.Windows.Forms.GroupBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.NovoEditandoBox.SuspendLayout();
            this.groupBoxPesquisaAndGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNascimento
            // 
            this.txtNascimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNascimento.Location = new System.Drawing.Point(158, 130);
            this.txtNascimento.Mask = "00/00/0000";
            this.txtNascimento.Name = "txtNascimento";
            this.txtNascimento.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNascimento.ShortcutsEnabled = false;
            this.txtNascimento.Size = new System.Drawing.Size(127, 27);
            this.txtNascimento.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 34;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(18, 231);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(764, 172);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView1_CellFormatting);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_CellMouseDoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView1_KeyDown);
            // 
            // txtMatricula
            // 
            this.txtMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.Location = new System.Drawing.Point(18, 56);
            this.txtMatricula.MaxLength = 9;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.ShortcutsEnabled = false;
            this.txtMatricula.Size = new System.Drawing.Size(118, 27);
            this.txtMatricula.TabIndex = 0;
            this.txtMatricula.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MatriculaBox_KeyPress);
            // 
            // comboSexo
            // 
            this.comboSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSexo.FormattingEnabled = true;
            this.comboSexo.Items.AddRange(new object[] {
            "Feminino",
            "Masculino"});
            this.comboSexo.Location = new System.Drawing.Point(19, 130);
            this.comboSexo.Name = "comboSexo";
            this.comboSexo.Size = new System.Drawing.Size(118, 28);
            this.comboSexo.TabIndex = 2;
            // 
            // NovoEditandoBox
            // 
            this.NovoEditandoBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NovoEditandoBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NovoEditandoBox.Controls.Add(this.txtNome);
            this.NovoEditandoBox.Controls.Add(this.NomeLabel);
            this.NovoEditandoBox.Controls.Add(this.MatriculaLabel);
            this.NovoEditandoBox.Controls.Add(this.txtMatricula);
            this.NovoEditandoBox.Controls.Add(this.SexoLabel);
            this.NovoEditandoBox.Controls.Add(this.comboSexo);
            this.NovoEditandoBox.Controls.Add(this.NascimentoLabel);
            this.NovoEditandoBox.Controls.Add(this.txtNascimento);
            this.NovoEditandoBox.Controls.Add(this.CPFLabel);
            this.NovoEditandoBox.Controls.Add(this.txtCPF);
            this.NovoEditandoBox.Controls.Add(this.btnLimpar);
            this.NovoEditandoBox.Controls.Add(this.btnAdicionar);
            this.NovoEditandoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NovoEditandoBox.Location = new System.Drawing.Point(12, 12);
            this.NovoEditandoBox.Name = "NovoEditandoBox";
            this.NovoEditandoBox.Size = new System.Drawing.Size(776, 170);
            this.NovoEditandoBox.TabIndex = 5;
            this.NovoEditandoBox.TabStop = false;
            this.NovoEditandoBox.Text = "Novo aluno";
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(158, 56);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.ShortcutsEnabled = false;
            this.txtNome.Size = new System.Drawing.Size(612, 27);
            this.txtNome.TabIndex = 1;
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NomeBox_KeyPress);
            // 
            // NomeLabel
            // 
            this.NomeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NomeLabel.Location = new System.Drawing.Point(155, 38);
            this.NomeLabel.Name = "NomeLabel";
            this.NomeLabel.Size = new System.Drawing.Size(90, 15);
            this.NomeLabel.TabIndex = 15;
            this.NomeLabel.Text = "Nome *";
            // 
            // MatriculaLabel
            // 
            this.MatriculaLabel.Location = new System.Drawing.Point(16, 38);
            this.MatriculaLabel.Name = "MatriculaLabel";
            this.MatriculaLabel.Size = new System.Drawing.Size(78, 15);
            this.MatriculaLabel.TabIndex = 16;
            this.MatriculaLabel.Text = "Matrícula *";
            // 
            // SexoLabel
            // 
            this.SexoLabel.Location = new System.Drawing.Point(16, 112);
            this.SexoLabel.Name = "SexoLabel";
            this.SexoLabel.Size = new System.Drawing.Size(48, 15);
            this.SexoLabel.TabIndex = 12;
            this.SexoLabel.Text = "Sexo *";
            // 
            // NascimentoLabel
            // 
            this.NascimentoLabel.Location = new System.Drawing.Point(155, 112);
            this.NascimentoLabel.Name = "NascimentoLabel";
            this.NascimentoLabel.Size = new System.Drawing.Size(97, 15);
            this.NascimentoLabel.TabIndex = 14;
            this.NascimentoLabel.Text = "Nascimento *";
            // 
            // CPFLabel
            // 
            this.CPFLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CPFLabel.Location = new System.Drawing.Point(298, 112);
            this.CPFLabel.Name = "CPFLabel";
            this.CPFLabel.Size = new System.Drawing.Size(143, 15);
            this.CPFLabel.TabIndex = 13;
            this.CPFLabel.Text = "CPF (Opcional)";
            // 
            // txtCPF
            // 
            this.txtCPF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPF.Location = new System.Drawing.Point(301, 130);
            this.txtCPF.MaxLength = 11;
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(235, 27);
            this.txtCPF.TabIndex = 4;
            this.txtCPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CpfBox_KeyPress);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(552, 127);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(106, 30);
            this.btnLimpar.TabIndex = 5;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.LimparOuCancelarBtn_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.Location = new System.Drawing.Point(664, 127);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(106, 30);
            this.btnAdicionar.TabIndex = 6;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.AdicionarOuModificarBtn_Click);
            // 
            // txtBarraDePesquisa
            // 
            this.txtBarraDePesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarraDePesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarraDePesquisa.Location = new System.Drawing.Point(6, 10);
            this.txtBarraDePesquisa.Name = "txtBarraDePesquisa";
            this.txtBarraDePesquisa.Size = new System.Drawing.Size(657, 27);
            this.txtBarraDePesquisa.TabIndex = 7;
            this.txtBarraDePesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BarraDePesquisa_KeyDown);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(667, 221);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(103, 34);
            this.btnExcluir.TabIndex = 10;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.ExcluirBtn_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(560, 221);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(103, 34);
            this.btnEditar.TabIndex = 9;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.EditarBtn_Click);
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisa.Location = new System.Drawing.Point(669, 8);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(101, 33);
            this.btnPesquisa.TabIndex = 8;
            this.btnPesquisa.Text = "Pesquisar";
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.PesquisaBox_Click);
            // 
            // groupBoxPesquisaAndGrid
            // 
            this.groupBoxPesquisaAndGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPesquisaAndGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxPesquisaAndGrid.Controls.Add(this.btnEditar);
            this.groupBoxPesquisaAndGrid.Controls.Add(this.btnPesquisa);
            this.groupBoxPesquisaAndGrid.Controls.Add(this.btnExcluir);
            this.groupBoxPesquisaAndGrid.Controls.Add(this.txtBarraDePesquisa);
            this.groupBoxPesquisaAndGrid.Location = new System.Drawing.Point(12, 188);
            this.groupBoxPesquisaAndGrid.Name = "groupBoxPesquisaAndGrid";
            this.groupBoxPesquisaAndGrid.Size = new System.Drawing.Size(776, 266);
            this.groupBoxPesquisaAndGrid.TabIndex = 12;
            this.groupBoxPesquisaAndGrid.TabStop = false;
            // 
            // CadastroAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.NovoEditandoBox);
            this.Controls.Add(this.groupBoxPesquisaAndGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(814, 483);
            this.Name = "CadastroAluno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EscolarManager - Cadastro de aluno";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.NovoEditandoBox.ResumeLayout(false);
            this.NovoEditandoBox.PerformLayout();
            this.groupBoxPesquisaAndGrid.ResumeLayout(false);
            this.groupBoxPesquisaAndGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtNascimento;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.ComboBox comboSexo;
        private System.Windows.Forms.GroupBox NovoEditandoBox;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label NascimentoLabel;
        private System.Windows.Forms.Label CPFLabel;
        private System.Windows.Forms.Label SexoLabel;
        private System.Windows.Forms.Label NomeLabel;
        private System.Windows.Forms.Label MatriculaLabel;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.TextBox txtBarraDePesquisa;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.GroupBox groupBoxPesquisaAndGrid;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

