namespace RodaRodaJequitiClient
{
    partial class Client
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
            this.label1 = new System.Windows.Forms.Label();
            this.player = new System.Windows.Forms.Label();
            this.palavra01 = new System.Windows.Forms.Label();
            this.palavra02 = new System.Windows.Forms.Label();
            this.palavra03 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.letra = new System.Windows.Forms.TextBox();
            this.sendLetra = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pontos1 = new System.Windows.Forms.Label();
            this.pontos2 = new System.Windows.Forms.Label();
            this.pontos3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.valendo = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.msg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 27);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vez do Jogador";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // player
            // 
            this.player.AutoSize = true;
            this.player.Location = new System.Drawing.Point(119, 27);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(13, 13);
            this.player.TabIndex = 1;
            this.player.Text = "1";
            this.player.Click += new System.EventHandler(this.player_Click);
            // 
            // palavra01
            // 
            this.palavra01.AutoSize = true;
            this.palavra01.Location = new System.Drawing.Point(12, 127);
            this.palavra01.Name = "palavra01";
            this.palavra01.Size = new System.Drawing.Size(61, 13);
            this.palavra01.TabIndex = 2;
            this.palavra01.Text = "Palavra 01:";
            this.palavra01.Click += new System.EventHandler(this.label2_Click);
            // 
            // palavra02
            // 
            this.palavra02.AutoSize = true;
            this.palavra02.Location = new System.Drawing.Point(12, 180);
            this.palavra02.Name = "palavra02";
            this.palavra02.Size = new System.Drawing.Size(61, 13);
            this.palavra02.TabIndex = 3;
            this.palavra02.Text = "Palavra 02:";
            // 
            // palavra03
            // 
            this.palavra03.AutoSize = true;
            this.palavra03.Location = new System.Drawing.Point(12, 241);
            this.palavra03.Name = "palavra03";
            this.palavra03.Size = new System.Drawing.Size(61, 13);
            this.palavra03.TabIndex = 4;
            this.palavra03.Text = "Palavra 03:";
            this.palavra03.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(511, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(511, 186);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(205, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(511, 247);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(205, 20);
            this.textBox3.TabIndex = 7;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Letra:";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // letra
            // 
            this.letra.Location = new System.Drawing.Point(511, 79);
            this.letra.Name = "letra";
            this.letra.Size = new System.Drawing.Size(100, 20);
            this.letra.TabIndex = 9;
            // 
            // sendLetra
            // 
            this.sendLetra.Location = new System.Drawing.Point(646, 77);
            this.sendLetra.Name = "sendLetra";
            this.sendLetra.Size = new System.Drawing.Size(75, 23);
            this.sendLetra.TabIndex = 10;
            this.sendLetra.Text = "Enviar";
            this.sendLetra.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.sendLetra.UseVisualStyleBackColor = true;
            this.sendLetra.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(722, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Enviar";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(722, 186);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Enviar";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(722, 127);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Enviar";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "label5";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "PONTOS:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 351);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Jogador 1:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 379);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Jogador 2:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 405);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Jogador 3:";
            // 
            // pontos1
            // 
            this.pontos1.AutoSize = true;
            this.pontos1.Location = new System.Drawing.Point(80, 351);
            this.pontos1.Name = "pontos1";
            this.pontos1.Size = new System.Drawing.Size(13, 13);
            this.pontos1.TabIndex = 22;
            this.pontos1.Text = "0";
            // 
            // pontos2
            // 
            this.pontos2.AutoSize = true;
            this.pontos2.Location = new System.Drawing.Point(80, 379);
            this.pontos2.Name = "pontos2";
            this.pontos2.Size = new System.Drawing.Size(13, 13);
            this.pontos2.TabIndex = 23;
            this.pontos2.Text = "0";
            // 
            // pontos3
            // 
            this.pontos3.AutoSize = true;
            this.pontos3.Location = new System.Drawing.Point(80, 405);
            this.pontos3.Name = "pontos3";
            this.pontos3.Size = new System.Drawing.Size(13, 13);
            this.pontos3.TabIndex = 24;
            this.pontos3.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(511, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Valendo ";
            // 
            // valendo
            // 
            this.valendo.AutoSize = true;
            this.valendo.Location = new System.Drawing.Point(566, 27);
            this.valendo.Name = "valendo";
            this.valendo.Size = new System.Drawing.Size(13, 13);
            this.valendo.TabIndex = 26;
            this.valendo.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(596, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "pontos por letra acertada";
            // 
            // msg
            // 
            this.msg.AutoSize = true;
            this.msg.Location = new System.Drawing.Point(298, 379);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(27, 13);
            this.msg.TabIndex = 28;
            this.msg.Text = "Msg";
            this.msg.Click += new System.EventHandler(this.msg_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.msg);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.valendo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pontos3);
            this.Controls.Add(this.pontos2);
            this.Controls.Add(this.pontos1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sendLetra);
            this.Controls.Add(this.letra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.palavra03);
            this.Controls.Add(this.palavra02);
            this.Controls.Add(this.palavra01);
            this.Controls.Add(this.player);
            this.Controls.Add(this.label1);
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label player;
        private System.Windows.Forms.Label palavra01;
        private System.Windows.Forms.Label palavra02;
        private System.Windows.Forms.Label palavra03;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox letra;
        private System.Windows.Forms.Button sendLetra;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label pontos1;
        private System.Windows.Forms.Label pontos2;
        private System.Windows.Forms.Label pontos3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label valendo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label msg;
    }
}

