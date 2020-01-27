namespace IlacDepoStok
{
    partial class FormStokGiris
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
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnVazgec = new System.Windows.Forms.Button();
            this.lblAdet = new System.Windows.Forms.Label();
            this.txtAdet = new System.Windows.Forms.TextBox();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.lblTarih = new System.Windows.Forms.Label();
            this.lblIlacAdi = new System.Windows.Forms.Label();
            this.lblIlacAd = new System.Windows.Forms.Label();
            this.lblDepo = new System.Windows.Forms.Label();
            this.cmbDepo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(39, 177);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.Location = new System.Drawing.Point(160, 177);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(75, 23);
            this.btnVazgec.TabIndex = 1;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.UseVisualStyleBackColor = true;
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // lblAdet
            // 
            this.lblAdet.AutoSize = true;
            this.lblAdet.Location = new System.Drawing.Point(51, 86);
            this.lblAdet.Name = "lblAdet";
            this.lblAdet.Size = new System.Drawing.Size(42, 13);
            this.lblAdet.TabIndex = 2;
            this.lblAdet.Text = "ADET :";
            // 
            // txtAdet
            // 
            this.txtAdet.Location = new System.Drawing.Point(102, 83);
            this.txtAdet.Name = "txtAdet";
            this.txtAdet.Size = new System.Drawing.Size(120, 20);
            this.txtAdet.TabIndex = 3;
            this.txtAdet.Text = "0";
            // 
            // dtpTarih
            // 
            this.dtpTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTarih.Location = new System.Drawing.Point(102, 54);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(120, 20);
            this.dtpTarih.TabIndex = 6;
            this.dtpTarih.Visible = false;
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.Location = new System.Drawing.Point(12, 58);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(81, 13);
            this.lblTarih.TabIndex = 7;
            this.lblTarih.Text = "GİRİŞ TARİHİ :";
            this.lblTarih.Visible = false;
            // 
            // lblIlacAdi
            // 
            this.lblIlacAdi.AutoSize = true;
            this.lblIlacAdi.Location = new System.Drawing.Point(36, 31);
            this.lblIlacAdi.Name = "lblIlacAdi";
            this.lblIlacAdi.Size = new System.Drawing.Size(57, 13);
            this.lblIlacAdi.TabIndex = 8;
            this.lblIlacAdi.Text = "İLAÇ ADI :";
            // 
            // lblIlacAd
            // 
            this.lblIlacAd.AutoSize = true;
            this.lblIlacAd.Location = new System.Drawing.Point(102, 31);
            this.lblIlacAd.Name = "lblIlacAd";
            this.lblIlacAd.Size = new System.Drawing.Size(0, 13);
            this.lblIlacAd.TabIndex = 9;
            // 
            // lblDepo
            // 
            this.lblDepo.AutoSize = true;
            this.lblDepo.Location = new System.Drawing.Point(50, 116);
            this.lblDepo.Name = "lblDepo";
            this.lblDepo.Size = new System.Drawing.Size(43, 13);
            this.lblDepo.TabIndex = 10;
            this.lblDepo.Text = "DEPO :";
            // 
            // cmbDepo
            // 
            this.cmbDepo.FormattingEnabled = true;
            this.cmbDepo.Location = new System.Drawing.Point(102, 116);
            this.cmbDepo.Name = "cmbDepo";
            this.cmbDepo.Size = new System.Drawing.Size(120, 21);
            this.cmbDepo.TabIndex = 11;
            // 
            // FormStokGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 224);
            this.Controls.Add(this.cmbDepo);
            this.Controls.Add(this.lblDepo);
            this.Controls.Add(this.lblIlacAd);
            this.Controls.Add(this.lblIlacAdi);
            this.Controls.Add(this.lblTarih);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.txtAdet);
            this.Controls.Add(this.lblAdet);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnKaydet);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStokGiris";
            this.Text = "Stok Giriş";
            this.Load += new System.EventHandler(this.FormStokGiris_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnVazgec;
        private System.Windows.Forms.Label lblAdet;
        private System.Windows.Forms.TextBox txtAdet;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.Label lblIlacAdi;
        private System.Windows.Forms.Label lblIlacAd;
        private System.Windows.Forms.Label lblDepo;
        private System.Windows.Forms.ComboBox cmbDepo;
    }
}