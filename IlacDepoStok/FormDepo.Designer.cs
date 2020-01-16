namespace IlacDepoStok
{
    partial class FormDepo
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
            this.lblDepoAdi = new System.Windows.Forms.Label();
            this.txtDepoAdi = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.lstBoxDepolar = new System.Windows.Forms.ListBox();
            this.lblDepolar = new System.Windows.Forms.Label();
            this.btnDegistir = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnYeniEkle = new System.Windows.Forms.Button();
            this.btnVazgec = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDepoAdi
            // 
            this.lblDepoAdi.AutoSize = true;
            this.lblDepoAdi.Location = new System.Drawing.Point(12, 26);
            this.lblDepoAdi.Name = "lblDepoAdi";
            this.lblDepoAdi.Size = new System.Drawing.Size(64, 13);
            this.lblDepoAdi.TabIndex = 0;
            this.lblDepoAdi.Text = "DEPO ADI :";
            // 
            // txtDepoAdi
            // 
            this.txtDepoAdi.Enabled = false;
            this.txtDepoAdi.Location = new System.Drawing.Point(82, 23);
            this.txtDepoAdi.Name = "txtDepoAdi";
            this.txtDepoAdi.Size = new System.Drawing.Size(132, 20);
            this.txtDepoAdi.TabIndex = 1;
            // 
            // btnEkle
            // 
            this.btnEkle.Enabled = false;
            this.btnEkle.Location = new System.Drawing.Point(311, 21);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Kaydet";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Enabled = false;
            this.btnSil.Location = new System.Drawing.Point(233, 145);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // lstBoxDepolar
            // 
            this.lstBoxDepolar.FormattingEnabled = true;
            this.lstBoxDepolar.Location = new System.Drawing.Point(82, 87);
            this.lstBoxDepolar.Name = "lstBoxDepolar";
            this.lstBoxDepolar.Size = new System.Drawing.Size(132, 173);
            this.lstBoxDepolar.TabIndex = 4;
            this.lstBoxDepolar.SelectedIndexChanged += new System.EventHandler(this.lstBoxDepolar_SelectedIndexChanged);
            // 
            // lblDepolar
            // 
            this.lblDepolar.AutoSize = true;
            this.lblDepolar.Location = new System.Drawing.Point(12, 87);
            this.lblDepolar.Name = "lblDepolar";
            this.lblDepolar.Size = new System.Drawing.Size(64, 13);
            this.lblDepolar.TabIndex = 5;
            this.lblDepolar.Text = "DEPOLAR :";
            // 
            // btnDegistir
            // 
            this.btnDegistir.Enabled = false;
            this.btnDegistir.Location = new System.Drawing.Point(233, 87);
            this.btnDegistir.Name = "btnDegistir";
            this.btnDegistir.Size = new System.Drawing.Size(75, 23);
            this.btnDegistir.TabIndex = 6;
            this.btnDegistir.Text = "Değiştir";
            this.btnDegistir.UseVisualStyleBackColor = true;
            this.btnDegistir.Click += new System.EventHandler(this.btnDegistir_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Enabled = false;
            this.btnKaydet.Location = new System.Drawing.Point(233, 116);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 7;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnYeniEkle
            // 
            this.btnYeniEkle.Location = new System.Drawing.Point(233, 21);
            this.btnYeniEkle.Name = "btnYeniEkle";
            this.btnYeniEkle.Size = new System.Drawing.Size(75, 23);
            this.btnYeniEkle.TabIndex = 8;
            this.btnYeniEkle.Text = "Yeni Ekle";
            this.btnYeniEkle.UseVisualStyleBackColor = true;
            this.btnYeniEkle.Click += new System.EventHandler(this.btnYeniEkle_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.Enabled = false;
            this.btnVazgec.Location = new System.Drawing.Point(392, 21);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(75, 23);
            this.btnVazgec.TabIndex = 9;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.UseVisualStyleBackColor = true;
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // FormDepo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 299);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnYeniEkle);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnDegistir);
            this.Controls.Add(this.lblDepolar);
            this.Controls.Add(this.lstBoxDepolar);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtDepoAdi);
            this.Controls.Add(this.lblDepoAdi);
            this.Name = "FormDepo";
            this.Text = "Depolar";
            this.Load += new System.EventHandler(this.FormDepo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDepoAdi;
        private System.Windows.Forms.TextBox txtDepoAdi;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.ListBox lstBoxDepolar;
        private System.Windows.Forms.Label lblDepolar;
        private System.Windows.Forms.Button btnDegistir;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnYeniEkle;
        private System.Windows.Forms.Button btnVazgec;
    }
}