namespace RodaRodaJequitiClient
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
            this.btnJogar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNamePlayer = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.palavra03 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.palavra02 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.palavra01 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rb_chat = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPalavra01 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnPalavra02 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnPalavra03 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnLetra = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLetra = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pontos = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnJogar
            // 
            this.btnJogar.Location = new System.Drawing.Point(251, 6);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(75, 23);
            this.btnJogar.TabIndex = 11;
            this.btnJogar.Text = "Jogar";
            this.btnJogar.UseVisualStyleBackColor = true;
            this.btnJogar.Click += new System.EventHandler(this.btnJogar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nome:";
            // 
            // txtNamePlayer
            // 
            this.txtNamePlayer.Location = new System.Drawing.Point(69, 9);
            this.txtNamePlayer.Name = "txtNamePlayer";
            this.txtNamePlayer.Size = new System.Drawing.Size(172, 20);
            this.txtNamePlayer.TabIndex = 9;
            this.txtNamePlayer.TextChanged += new System.EventHandler(this.txName_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.palavra03);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.palavra02);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.palavra01);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rb_chat);
            this.groupBox1.Location = new System.Drawing.Point(31, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 180);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "JOGO";
            // 
            // palavra03
            // 
            this.palavra03.AutoSize = true;
            this.palavra03.Location = new System.Drawing.Point(82, 123);
            this.palavra03.Name = "palavra03";
            this.palavra03.Size = new System.Drawing.Size(54, 13);
            this.palavra03.TabIndex = 7;
            this.palavra03.Text = "palavra03";
            this.palavra03.Click += new System.EventHandler(this.palavra03_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Palavra03:";
            // 
            // palavra02
            // 
            this.palavra02.AutoSize = true;
            this.palavra02.Location = new System.Drawing.Point(82, 85);
            this.palavra02.Name = "palavra02";
            this.palavra02.Size = new System.Drawing.Size(35, 13);
            this.palavra02.TabIndex = 5;
            this.palavra02.Text = "label3";
            this.palavra02.Click += new System.EventHandler(this.palavra02_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Palavra02:";
            // 
            // palavra01
            // 
            this.palavra01.AutoSize = true;
            this.palavra01.Location = new System.Drawing.Point(82, 51);
            this.palavra01.Name = "palavra01";
            this.palavra01.Size = new System.Drawing.Size(35, 13);
            this.palavra01.TabIndex = 3;
            this.palavra01.Text = "label3";
            this.palavra01.Click += new System.EventHandler(this.palavra01_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Palavra01:";
            // 
            // rb_chat
            // 
            this.rb_chat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rb_chat.Location = new System.Drawing.Point(3, 16);
            this.rb_chat.Name = "rb_chat";
            this.rb_chat.Size = new System.Drawing.Size(204, 161);
            this.rb_chat.TabIndex = 1;
            this.rb_chat.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(251, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(181, 180);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mensagens";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "log";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // btnPalavra01
            // 
            this.btnPalavra01.Location = new System.Drawing.Point(251, 287);
            this.btnPalavra01.Name = "btnPalavra01";
            this.btnPalavra01.Size = new System.Drawing.Size(75, 23);
            this.btnPalavra01.TabIndex = 16;
            this.btnPalavra01.Text = "Enviar";
            this.btnPalavra01.UseVisualStyleBackColor = true;
            this.btnPalavra01.Click += new System.EventHandler(this.btnPalavra01_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 290);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(172, 20);
            this.textBox1.TabIndex = 14;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnPalavra02
            // 
            this.btnPalavra02.Location = new System.Drawing.Point(252, 327);
            this.btnPalavra02.Name = "btnPalavra02";
            this.btnPalavra02.Size = new System.Drawing.Size(75, 23);
            this.btnPalavra02.TabIndex = 19;
            this.btnPalavra02.Text = "Enviar";
            this.btnPalavra02.UseVisualStyleBackColor = true;
            this.btnPalavra02.Click += new System.EventHandler(this.btnPalavra02_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(70, 330);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(172, 20);
            this.textBox2.TabIndex = 17;
            // 
            // btnPalavra03
            // 
            this.btnPalavra03.Location = new System.Drawing.Point(251, 370);
            this.btnPalavra03.Name = "btnPalavra03";
            this.btnPalavra03.Size = new System.Drawing.Size(75, 23);
            this.btnPalavra03.TabIndex = 22;
            this.btnPalavra03.Text = "Enviar";
            this.btnPalavra03.UseVisualStyleBackColor = true;
            this.btnPalavra03.Click += new System.EventHandler(this.btnPalavra03_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(69, 373);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(172, 20);
            this.textBox3.TabIndex = 20;
            // 
            // btnLetra
            // 
            this.btnLetra.Location = new System.Drawing.Point(159, 261);
            this.btnLetra.Name = "btnLetra";
            this.btnLetra.Size = new System.Drawing.Size(75, 23);
            this.btnLetra.TabIndex = 25;
            this.btnLetra.Text = "Enviar";
            this.btnLetra.UseVisualStyleBackColor = true;
            this.btnLetra.Click += new System.EventHandler(this.btnLetra_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 264);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Letra:";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // txtLetra
            // 
            this.txtLetra.Location = new System.Drawing.Point(70, 261);
            this.txtLetra.Name = "txtLetra";
            this.txtLetra.Size = new System.Drawing.Size(83, 20);
            this.txtLetra.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 293);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Palavra01:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 379);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Palavra03:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 337);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Palavra02:";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Pontos:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // pontos
            // 
            this.pontos.AutoSize = true;
            this.pontos.Location = new System.Drawing.Point(119, 222);
            this.pontos.Name = "pontos";
            this.pontos.Size = new System.Drawing.Size(13, 13);
            this.pontos.TabIndex = 30;
            this.pontos.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 405);
            this.Controls.Add(this.pontos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnLetra);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtLetra);
            this.Controls.Add(this.btnPalavra03);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.btnPalavra02);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnPalavra01);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnJogar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNamePlayer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Closed += new System.EventHandler(this.Form1_Closing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnJogar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNamePlayer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label palavra03;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label palavra02;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label palavra01;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rb_chat;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPalavra01;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnPalavra02;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnPalavra03;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnLetra;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLetra;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label pontos;
    }
}

