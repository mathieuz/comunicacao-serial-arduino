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
            this.groupBox_Saida = new System.Windows.Forms.GroupBox();
            this.consoleSaida = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_Enviar.SuspendLayout();
            this.groupBox_Saida.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btConectar
            // 
            this.btConectar.Location = new System.Drawing.Point(12, 43);
            this.btConectar.Name = "btConectar";
            this.btConectar.Size = new System.Drawing.Size(90, 21);
            this.btConectar.TabIndex = 0;
            this.btConectar.Text = "Conectar";
            this.btConectar.UseVisualStyleBackColor = true;
            this.btConectar.Click += new System.EventHandler(this.btConectar_Click);
            // 
            // comboBoxCOM
            // 
            this.comboBoxCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCOM.FormattingEnabled = true;
            this.comboBoxCOM.Location = new System.Drawing.Point(108, 43);
            this.comboBoxCOM.Name = "comboBoxCOM";
            this.comboBoxCOM.Size = new System.Drawing.Size(335, 21);
            this.comboBoxCOM.TabIndex = 1;
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(6, 44);
            this.txt1.MaxLength = 16;
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(347, 21);
            this.txt1.TabIndex = 2;
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(6, 81);
            this.txt2.MaxLength = 16;
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(347, 21);
            this.txt2.TabIndex = 3;
            // 
            // txt3
            // 
            this.txt3.Location = new System.Drawing.Point(6, 116);
            this.txt3.MaxLength = 16;
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(347, 21);
            this.txt3.TabIndex = 4;
            // 
            // btEnviar
            // 
            this.btEnviar.Location = new System.Drawing.Point(365, 44);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(60, 92);
            this.btEnviar.TabIndex = 7;
            this.btEnviar.Text = "Enviar";
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // groupBox_Enviar
            // 
            this.groupBox_Enviar.Controls.Add(this.txt1);
            this.groupBox_Enviar.Controls.Add(this.btEnviar);
            this.groupBox_Enviar.Controls.Add(this.txt2);
            this.groupBox_Enviar.Controls.Add(this.txt3);
            this.groupBox_Enviar.Enabled = false;
            this.groupBox_Enviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Enviar.Location = new System.Drawing.Point(12, 95);
            this.groupBox_Enviar.Name = "groupBox_Enviar";
            this.groupBox_Enviar.Size = new System.Drawing.Size(431, 153);
            this.groupBox_Enviar.TabIndex = 8;
            this.groupBox_Enviar.TabStop = false;
            this.groupBox_Enviar.Text = "Enviar";
            // 
            // groupBox_Saida
            // 
            this.groupBox_Saida.Controls.Add(this.consoleSaida);
            this.groupBox_Saida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Saida.Location = new System.Drawing.Point(12, 275);
            this.groupBox_Saida.Name = "groupBox_Saida";
            this.groupBox_Saida.Size = new System.Drawing.Size(431, 153);
            this.groupBox_Saida.TabIndex = 9;
            this.groupBox_Saida.TabStop = false;
            this.groupBox_Saida.Text = "Saída";
            // 
            // consoleSaida
            // 
            this.consoleSaida.BackColor = System.Drawing.SystemColors.Desktop;
            this.consoleSaida.Enabled = false;
            this.consoleSaida.Location = new System.Drawing.Point(6, 20);
            this.consoleSaida.Multiline = true;
            this.consoleSaida.Name = "consoleSaida";
            this.consoleSaida.Size = new System.Drawing.Size(419, 127);
            this.consoleSaida.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(455, 24);
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
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            // 
            // salvarComoToolStripMenuItem
            // 
            this.salvarComoToolStripMenuItem.Enabled = false;
            this.salvarComoToolStripMenuItem.Name = "salvarComoToolStripMenuItem";
            this.salvarComoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.ClientSize = new System.Drawing.Size(455, 437);
            this.Controls.Add(this.groupBox_Saida);
            this.Controls.Add(this.groupBox_Enviar);
            this.Controls.Add(this.comboBoxCOM);
            this.Controls.Add(this.btConectar);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Comunicação Serial - Arduino";
            this.groupBox_Enviar.ResumeLayout(false);
            this.groupBox_Enviar.PerformLayout();
            this.groupBox_Saida.ResumeLayout(false);
            this.groupBox_Saida.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btConectar;
        private System.Windows.Forms.ComboBox comboBoxCOM;
        private System.Windows.Forms.TextBox txt1;
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
    }
}

