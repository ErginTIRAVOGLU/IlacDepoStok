namespace IlacDepoStok
{
    partial class FormCari
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
            this.lstBoxKategori = new System.Windows.Forms.ListBox();
            this.lstBoxCari = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCariAdi = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtKategoriAdi = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstBoxKategori
            // 
            this.lstBoxKategori.FormattingEnabled = true;
            this.lstBoxKategori.Location = new System.Drawing.Point(7, 88);
            this.lstBoxKategori.Name = "lstBoxKategori";
            this.lstBoxKategori.Size = new System.Drawing.Size(181, 316);
            this.lstBoxKategori.TabIndex = 3;
            this.lstBoxKategori.SelectedIndexChanged += new System.EventHandler(this.lstBoxKategori_SelectedIndexChanged);
            // 
            // lstBoxCari
            // 
            this.lstBoxCari.FormattingEnabled = true;
            this.lstBoxCari.Location = new System.Drawing.Point(6, 88);
            this.lstBoxCari.Name = "lstBoxCari";
            this.lstBoxCari.Size = new System.Drawing.Size(181, 316);
            this.lstBoxCari.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(6, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Ekle";
            this.button2.UseCompatibleTextRendering = true;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Location = new System.Drawing.Point(72, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Düzenle";
            this.button3.UseCompatibleTextRendering = true;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Location = new System.Drawing.Point(138, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(49, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Sil";
            this.button4.UseCompatibleTextRendering = true;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.Location = new System.Drawing.Point(138, 23);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(49, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "Sil";
            this.button5.UseCompatibleTextRendering = true;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.Location = new System.Drawing.Point(72, 23);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(60, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "Düzenle";
            this.button6.UseCompatibleTextRendering = true;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.Location = new System.Drawing.Point(6, 23);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(60, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "Ekle";
            this.button7.UseCompatibleTextRendering = true;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCariAdi);
            this.groupBox1.Controls.Add(this.lstBoxCari);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Location = new System.Drawing.Point(218, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 411);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cari Adi";
            // 
            // txtCariAdi
            // 
            this.txtCariAdi.Location = new System.Drawing.Point(6, 51);
            this.txtCariAdi.Margin = new System.Windows.Forms.Padding(2);
            this.txtCariAdi.Multiline = true;
            this.txtCariAdi.Name = "txtCariAdi";
            this.txtCariAdi.Size = new System.Drawing.Size(182, 28);
            this.txtCariAdi.TabIndex = 11;
            this.txtCariAdi.TextChanged += new System.EventHandler(this.txtCariAdi_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtKategoriAdi);
            this.groupBox2.Controls.Add(this.lstBoxKategori);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 411);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kategori Adı";
            // 
            // txtKategoriAdi
            // 
            this.txtKategoriAdi.Location = new System.Drawing.Point(7, 51);
            this.txtKategoriAdi.Multiline = true;
            this.txtKategoriAdi.Name = "txtKategoriAdi";
            this.txtKategoriAdi.Size = new System.Drawing.Size(180, 28);
            this.txtKategoriAdi.TabIndex = 8;
            this.txtKategoriAdi.TextChanged += new System.EventHandler(this.txtKategoriAdi_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(438, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 59);
            this.button1.TabIndex = 13;
            this.button1.Text = "İlaç Hareket";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(438, 351);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 65);
            this.button8.TabIndex = 14;
            this.button8.Text = "Cari Hareket";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // FormCari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 431);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormCari";
            this.Text = "Cari";
            this.Load += new System.EventHandler(this.FormCari_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lstBoxKategori;
        private System.Windows.Forms.ListBox lstBoxCari;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCariAdi;
        private System.Windows.Forms.TextBox txtKategoriAdi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button8;
    }
}