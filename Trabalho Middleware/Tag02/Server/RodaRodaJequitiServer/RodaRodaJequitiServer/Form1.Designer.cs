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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lb_stt = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_soluong = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.list_Client = new System.Windows.Forms.CheckedListBox();
            this.rich_Text = new System.Windows.Forms.RichTextBox();
            this.log = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_stt,
            this.lb_soluong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 434);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(905, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lb_stt
            // 
            this.lb_stt.Name = "lb_stt";
            this.lb_stt.Size = new System.Drawing.Size(118, 17);
            this.lb_stt.Text = "toolStripStatusLabel1";
            // 
            // lb_soluong
            // 
            this.lb_soluong.Name = "lb_soluong";
            this.lb_soluong.Size = new System.Drawing.Size(118, 17);
            this.lb_soluong.Text = "toolStripStatusLabel1";
            this.lb_soluong.Click += new System.EventHandler(this.lb_soluong_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.list_Client);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 391);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List Client";
            // 
            // list_Client
            // 
            this.list_Client.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_Client.FormattingEnabled = true;
            this.list_Client.Location = new System.Drawing.Point(3, 16);
            this.list_Client.Name = "list_Client";
            this.list_Client.Size = new System.Drawing.Size(205, 372);
            this.list_Client.TabIndex = 5;
            // 
            // rich_Text
            // 
            this.rich_Text.Location = new System.Drawing.Point(229, 28);
            this.rich_Text.Name = "rich_Text";
            this.rich_Text.Size = new System.Drawing.Size(664, 375);
            this.rich_Text.TabIndex = 5;
            this.rich_Text.Text = "";
            // 
            // log
            // 
            this.log.AutoSize = true;
            this.log.Location = new System.Drawing.Point(239, 31);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(21, 13);
            this.log.TabIndex = 7;
            this.log.Text = "log";
            this.log.Click += new System.EventHandler(this.log_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 456);
            this.Controls.Add(this.log);
            this.Controls.Add(this.rich_Text);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.Load += new System.EventHandler(this.frm_Server_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lb_stt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox list_Client;
        private System.Windows.Forms.ToolStripStatusLabel lb_soluong;
        private System.Windows.Forms.RichTextBox rich_Text;
        private System.Windows.Forms.Label log;
    }
}

