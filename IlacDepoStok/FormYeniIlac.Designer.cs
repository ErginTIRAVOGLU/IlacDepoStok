﻿namespace IlacDepoStok
{
    partial class FormYeniIlac
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
            this.lblIacNotu = new System.Windows.Forms.Label();
            this.txtIlacAdi = new System.Windows.Forms.TextBox();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.lblIlacAdi = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtIlacNotu = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnVazgec = new System.Windows.Forms.Button();
            this.txtDusukStok = new System.Windows.Forms.TextBox();
            this.lblDusukStok = new System.Windows.Forms.Label();
            this.txtFiyat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblIacNotu
            // 
            this.lblIacNotu.AutoSize = true;
            this.lblIacNotu.Location = new System.Drawing.Point(27, 159);
            this.lblIacNotu.Name = "lblIacNotu";
            this.lblIacNotu.Size = new System.Drawing.Size(70, 13);
            this.lblIacNotu.TabIndex = 14;
            this.lblIacNotu.Text = "İLAÇ NOTU :";
            // 
            // txtIlacAdi
            // 
            this.txtIlacAdi.Location = new System.Drawing.Point(103, 62);
            this.txtIlacAdi.Name = "txtIlacAdi";
            this.txtIlacAdi.Size = new System.Drawing.Size(156, 20);
            this.txtIlacAdi.TabIndex = 12;
            // 
            // txtBarkod
            // 
            this.txtBarkod.Location = new System.Drawing.Point(103, 28);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(156, 20);
            this.txtBarkod.TabIndex = 11;
            // 
            // lblIlacAdi
            // 
            this.lblIlacAdi.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.lblIlacAdi.AutoSize = true;
            this.lblIlacAdi.Location = new System.Drawing.Point(41, 65);
            this.lblIlacAdi.Name = "lblIlacAdi";
            this.lblIlacAdi.Size = new System.Drawing.Size(57, 13);
            this.lblIlacAdi.TabIndex = 10;
            this.lblIlacAdi.Text = "İLAÇ ADI :";
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(40, 31);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(58, 13);
            this.lblBarcode.TabIndex = 9;
            this.lblBarcode.Text = "BARKOD :";
            // 
            // txtIlacNotu
            // 
            this.txtIlacNotu.Location = new System.Drawing.Point(103, 159);
            this.txtIlacNotu.Multiline = true;
            this.txtIlacNotu.Name = "txtIlacNotu";
            this.txtIlacNotu.Size = new System.Drawing.Size(231, 73);
            this.txtIlacNotu.TabIndex = 14;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(66, 253);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 15;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.Location = new System.Drawing.Point(183, 253);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(75, 23);
            this.btnVazgec.TabIndex = 16;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.UseVisualStyleBackColor = true;
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // txtDusukStok
            // 
            this.txtDusukStok.Location = new System.Drawing.Point(102, 125);
            this.txtDusukStok.Name = "txtDusukStok";
            this.txtDusukStok.Size = new System.Drawing.Size(51, 20);
            this.txtDusukStok.TabIndex = 13;
            // 
            // lblDusukStok
            // 
            this.lblDusukStok.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.lblDusukStok.AutoSize = true;
            this.lblDusukStok.Location = new System.Drawing.Point(14, 128);
            this.lblDusukStok.Name = "lblDusukStok";
            this.lblDusukStok.Size = new System.Drawing.Size(83, 13);
            this.lblDusukStok.TabIndex = 18;
            this.lblDusukStok.Text = "DÜŞÜK STOK :";
            // 
            // txtFiyat
            // 
            this.txtFiyat.Location = new System.Drawing.Point(103, 94);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Size = new System.Drawing.Size(50, 20);
            this.txtFiyat.TabIndex = 19;
            this.txtFiyat.TextChanged += new System.EventHandler(this.txtFiyat_TextChanged);
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "SATIŞ FİYATI :";
            // 
            // FormYeniIlac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 315);
            this.Controls.Add(this.txtFiyat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDusukStok);
            this.Controls.Add(this.lblDusukStok);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtIlacNotu);
            this.Controls.Add(this.lblIacNotu);
            this.Controls.Add(this.txtIlacAdi);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.lblIlacAdi);
            this.Controls.Add(this.lblBarcode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormYeniIlac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni İlaç Ekle";
            this.Load += new System.EventHandler(this.FormYeniIlac_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIacNotu;
        private System.Windows.Forms.TextBox txtIlacAdi;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.Label lblIlacAdi;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtIlacNotu;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnVazgec;
        private System.Windows.Forms.TextBox txtDusukStok;
        private System.Windows.Forms.Label lblDusukStok;
        private System.Windows.Forms.TextBox txtFiyat;
        private System.Windows.Forms.Label label1;
    }
}