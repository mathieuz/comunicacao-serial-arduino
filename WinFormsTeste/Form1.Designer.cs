namespace WinFormsTeste
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btConectar = new System.Windows.Forms.Button();
            this.comboBoxCOM = new System.Windows.Forms.ComboBox();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.btEnviar = new System.Windows.Forms.Button();
            this.groupBox_Enviar = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.upDownUplink = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxClasse = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxModoOperacao = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_Saida = new System.Windows.Forms.GroupBox();
            this.consoleSaida = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_Enviar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownUplink)).BeginInit();
            this.groupBox_Saida.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btConectar
            // 
            this.btConectar.Location = new System.Drawing.Point(12, 43);
            this.btConectar.Name = "btConectar";
            this.btConectar.Size = new System.Drawing.Size(114, 21);
            this.btConectar.TabIndex = 0;
            this.btConectar.Text = "Conectar";
            this.btConectar.UseVisualStyleBackColor = true;
            this.btConectar.Click += new System.EventHandler(this.btConectar_Click);
            // 
            // comboBoxCOM
            // 
            this.comboBoxCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCOM.FormattingEnabled = true;
            this.comboBoxCOM.Location = new System.Drawing.Point(132, 44);
            this.comboBoxCOM.Name = "comboBoxCOM";
            this.comboBoxCOM.Size = new System.Drawing.Size(399, 21);
            this.comboBoxCOM.TabIndex = 1;
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(6, 44);
            this.txt1.MaxLength = 16;
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(507, 21);
            this.txt1.TabIndex = 2;
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(6, 102);
            this.txt2.MaxLength = 16;
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(507, 21);
            this.txt2.TabIndex = 3;
            // 
            // txt3
            // 
            this.txt3.Location = new System.Drawing.Point(6, 159);
            this.txt3.MaxLength = 16;
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(507, 21);
            this.txt3.TabIndex = 4;
            // 
            // btEnviar
            // 
            this.btEnviar.Location = new System.Drawing.Point(6, 323);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(507, 31);
            this.btEnviar.TabIndex = 7;
            this.btEnviar.Text = "Enviar";
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // groupBox_Enviar
            // 
            this.groupBox_Enviar.Controls.Add(this.label6);
            this.groupBox_Enviar.Controls.Add(this.upDownUplink);
            this.groupBox_Enviar.Controls.Add(this.label5);
            this.groupBox_Enviar.Controls.Add(this.comboBoxClasse);
            this.groupBox_Enviar.Controls.Add(this.label4);
            this.groupBox_Enviar.Controls.Add(this.comboBoxModoOperacao);
            this.groupBox_Enviar.Controls.Add(this.label3);
            this.groupBox_Enviar.Controls.Add(this.label2);
            this.groupBox_Enviar.Controls.Add(this.label1);
            this.groupBox_Enviar.Controls.Add(this.txt1);
            this.groupBox_Enviar.Controls.Add(this.btEnviar);
            this.groupBox_Enviar.Controls.Add(this.txt2);
            this.groupBox_Enviar.Controls.Add(this.txt3);
            this.groupBox_Enviar.Enabled = false;
            this.groupBox_Enviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Enviar.Location = new System.Drawing.Point(12, 95);
            this.groupBox_Enviar.Name = "groupBox_Enviar";
            this.groupBox_Enviar.Size = new System.Drawing.Size(519, 360);
            this.groupBox_Enviar.TabIndex = 8;
            this.groupBox_Enviar.TabStop = false;
            this.groupBox_Enviar.Text = "Enviar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Tempo em milissegundos de Uplink";
            // 
            // upDownUplink
            // 
            this.upDownUplink.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.upDownUplink.Location = new System.Drawing.Point(6, 276);
            this.upDownUplink.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.upDownUplink.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.upDownUplink.Name = "upDownUplink";
            this.upDownUplink.ReadOnly = true;
            this.upDownUplink.Size = new System.Drawing.Size(507, 21);
            this.upDownUplink.TabIndex = 18;
            this.upDownUplink.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Classe";
            // 
            // comboBoxClasse
            // 
            this.comboBoxClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClasse.FormattingEnabled = true;
            this.comboBoxClasse.Location = new System.Drawing.Point(268, 214);
            this.comboBoxClasse.Name = "comboBoxClasse";
            this.comboBoxClasse.Size = new System.Drawing.Size(245, 23);
            this.comboBoxClasse.TabIndex = 15;
            this.comboBoxClasse.SelectedIndexChanged += new System.EventHandler(this.comboBoxClasse_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Modo de Operação";
            // 
            // comboBoxModoOperacao
            // 
            this.comboBoxModoOperacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModoOperacao.FormattingEnabled = true;
            this.comboBoxModoOperacao.Location = new System.Drawing.Point(6, 214);
            this.comboBoxModoOperacao.Name = "comboBoxModoOperacao";
            this.comboBoxModoOperacao.Size = new System.Drawing.Size(245, 23);
            this.comboBoxModoOperacao.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "NWKSKEY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "APPSKEY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "APPKEY";
            // 
            // groupBox_Saida
            // 
            this.groupBox_Saida.Controls.Add(this.consoleSaida);
            this.groupBox_Saida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Saida.Location = new System.Drawing.Point(12, 461);
            this.groupBox_Saida.Name = "groupBox_Saida";
            this.groupBox_Saida.Size = new System.Drawing.Size(519, 143);
            this.groupBox_Saida.TabIndex = 9;
            this.groupBox_Saida.TabStop = false;
            this.groupBox_Saida.Text = "Saída";
            // 
            // consoleSaida
            // 
            this.consoleSaida.BackColor = System.Drawing.SystemColors.Desktop;
            this.consoleSaida.Location = new System.Drawing.Point(6, 26);
            this.consoleSaida.Multiline = true;
            this.consoleSaida.Name = "consoleSaida";
            this.consoleSaida.ReadOnly = true;
            this.consoleSaida.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleSaida.Size = new System.Drawing.Size(507, 111);
            this.consoleSaida.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(543, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.salvarComoToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Enabled = false;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // salvarComoToolStripMenuItem
            // 
            this.salvarComoToolStripMenuItem.Enabled = false;
            this.salvarComoToolStripMenuItem.Name = "salvarComoToolStripMenuItem";
            this.salvarComoToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.salvarComoToolStripMenuItem.Text = "Salvar como...";
            this.salvarComoToolStripMenuItem.Click += new System.EventHandler(this.salvarComoToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(543, 616);
            this.Controls.Add(this.groupBox_Saida);
            this.Controls.Add(this.groupBox_Enviar);
            this.Controls.Add(this.comboBoxCOM);
            this.Controls.Add(this.btConectar);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comunicação Serial - Arduino";
            this.groupBox_Enviar.ResumeLayout(false);
            this.groupBox_Enviar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownUplink)).EndInit();
            this.groupBox_Saida.ResumeLayout(false);
            this.groupBox_Saida.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConectar;
        private System.Windows.Forms.ComboBox comboBoxCOM;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.GroupBox groupBox_Enviar;
        private System.Windows.Forms.GroupBox groupBox_Saida;
        private System.Windows.Forms.TextBox consoleSaida;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxClasse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxModoOperacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown upDownUplink;
    }
}

