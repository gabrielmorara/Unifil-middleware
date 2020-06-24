namespace RodaRodaJequitiServer
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.list_Client = new System.Windows.Forms.CheckedListBox();
            this.txtLetras = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pontos = new System.Windows.Forms.Label();
            this.pontosPalavra = new System.Windows.Forms.Label();
            this.pontosPorPalavra = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textLog = new System.Windows.Forms.TextBox();
            this.listPlacar = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.list_Client);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 227);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jogadores";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // list_Client
            // 
            this.list_Client.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_Client.FormattingEnabled = true;
            this.list_Client.Location = new System.Drawing.Point(3, 16);
            this.list_Client.Name = "list_Client";
            this.list_Client.Size = new System.Drawing.Size(109, 208);
            this.list_Client.TabIndex = 5;
            this.list_Client.SelectedIndexChanged += new System.EventHandler(this.list_Client_SelectedIndexChanged);
            // 
            // txtLetras
            // 
            this.txtLetras.Location = new System.Drawing.Point(298, 28);
            this.txtLetras.Multiline = true;
            this.txtLetras.Name = "txtLetras";
            this.txtLetras.Size = new System.Drawing.Size(248, 58);
            this.txtLetras.TabIndex = 4;
            this.txtLetras.TextChanged += new System.EventHandler(this.txtLetras_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Letras jogadas";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pontos por letra:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pontos
            // 
            this.pontos.AutoSize = true;
            this.pontos.Location = new System.Drawing.Point(312, 127);
            this.pontos.Name = "pontos";
            this.pontos.Size = new System.Drawing.Size(13, 13);
            this.pontos.TabIndex = 7;
            this.pontos.Text = "0";
            // 
            // pontosPalavra
            // 
            this.pontosPalavra.AutoSize = true;
            this.pontosPalavra.Location = new System.Drawing.Point(312, 189);
            this.pontosPalavra.Name = "pontosPalavra";
            this.pontosPalavra.Size = new System.Drawing.Size(13, 13);
            this.pontosPalavra.TabIndex = 9;
            this.pontosPalavra.Text = "0";
            this.pontosPalavra.Click += new System.EventHandler(this.label3_Click);
            // 
            // pontosPorPalavra
            // 
            this.pontosPorPalavra.AutoSize = true;
            this.pontosPorPalavra.Location = new System.Drawing.Point(312, 164);
            this.pontosPorPalavra.Name = "pontosPorPalavra";
            this.pontosPorPalavra.Size = new System.Drawing.Size(99, 13);
            this.pontosPorPalavra.TabIndex = 8;
            this.pontosPorPalavra.Text = "Pontos por palavra:";
            this.pontosPorPalavra.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Placar";
            // 
            // textLog
            // 
            this.textLog.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textLog.Location = new System.Drawing.Point(3, 245);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textLog.Size = new System.Drawing.Size(543, 117);
            this.textLog.TabIndex = 12;
            this.textLog.TextChanged += new System.EventHandler(this.textLog_TextChanged);
            // 
            // listPlacar
            // 
            this.listPlacar.HideSelection = false;
            this.listPlacar.Location = new System.Drawing.Point(146, 28);
            this.listPlacar.Name = "listPlacar";
            this.listPlacar.Size = new System.Drawing.Size(146, 208);
            this.listPlacar.TabIndex = 13;
            this.listPlacar.UseCompatibleStateImageBehavior = false;
            this.listPlacar.View = System.Windows.Forms.View.List;
            this.listPlacar.SelectedIndexChanged += new System.EventHandler(this.listPlacar_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 374);
            this.Controls.Add(this.listPlacar);
            this.Controls.Add(this.textLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pontosPalavra);
            this.Controls.Add(this.pontosPorPalavra);
            this.Controls.Add(this.pontos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLetras);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox list_Client;
        private System.Windows.Forms.TextBox txtLetras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label pontos;
        private System.Windows.Forms.Label pontosPalavra;
        private System.Windows.Forms.Label pontosPorPalavra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.ListView listPlacar;
    }
}

