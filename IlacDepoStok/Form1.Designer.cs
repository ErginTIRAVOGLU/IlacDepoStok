namespace IlacDepoStok
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblIlacAdi = new System.Windows.Forms.Label();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.txtIlacAdi = new System.Windows.Forms.TextBox();
            this.btnStokGiris = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dGVHareket = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblIacNot = new System.Windows.Forms.Label();
            this.lblIacNotu = new System.Windows.Forms.Label();
            this.btnIlacDuzenle = new System.Windows.Forms.Button();
            this.btnStokCikis = new System.Windows.Forms.Button();
            this.lblKalanStogu = new System.Windows.Forms.Label();
            this.lblKalanStok = new System.Windows.Forms.Label();
            this.lblCari = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGVHareket)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(34, 43);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(58, 13);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "BARKOD :";
            // 
            // lblIlacAdi
            // 
            this.lblIlacAdi.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.lblIlacAdi.AutoSize = true;
            this.lblIlacAdi.Location = new System.Drawing.Point(35, 77);
            this.lblIlacAdi.Name = "lblIlacAdi";
            this.lblIlacAdi.Size = new System.Drawing.Size(57, 13);
            this.lblIlacAdi.TabIndex = 1;
            this.lblIlacAdi.Text = "İLAÇ ADI :";
            // 
            // txtBarkod
            // 
            this.txtBarkod.Location = new System.Drawing.Point(98, 40);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(156, 20);
            this.txtBarkod.TabIndex = 2;
            this.txtBarkod.TextChanged += new System.EventHandler(this.txtBarkod_TextChanged);
            this.txtBarkod.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyUp);
            // 
            // txtIlacAdi
            // 
            this.txtIlacAdi.Location = new System.Drawing.Point(98, 74);
            this.txtIlacAdi.Name = "txtIlacAdi";
            this.txtIlacAdi.Size = new System.Drawing.Size(156, 20);
            this.txtIlacAdi.TabIndex = 3;
            // 
            // btnStokGiris
            // 
            this.btnStokGiris.Enabled = false;
            this.btnStokGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStokGiris.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStokGiris.ImageIndex = 2;
            this.btnStokGiris.ImageList = this.ımageList1;
            this.btnStokGiris.Location = new System.Drawing.Point(401, 130);
            this.btnStokGiris.Name = "btnStokGiris";
            this.btnStokGiris.Size = new System.Drawing.Size(75, 75);
            this.btnStokGiris.TabIndex = 4;
            this.btnStokGiris.Text = "Stok &Giriş";
            this.btnStokGiris.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStokGiris.UseCompatibleTextRendering = true;
            this.btnStokGiris.UseVisualStyleBackColor = false;
            this.btnStokGiris.Click += new System.EventHandler(this.btnStokGiris_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "logout-icon.png");
            this.ımageList1.Images.SetKeyName(1, "export-icon.png");
            this.ımageList1.Images.SetKeyName(2, "import-icon.png");
            this.ımageList1.Images.SetKeyName(3, "Button-Close-icon.png");
            this.ımageList1.Images.SetKeyName(4, "Button-Add-icon.png");
            this.ımageList1.Images.SetKeyName(5, "inventory-maintenance-icon.png");
            // 
            // dGVHareket
            // 
            this.dGVHareket.AllowUserToAddRows = false;
            this.dGVHareket.AllowUserToDeleteRows = false;
            this.dGVHareket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVHareket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVHareket.Location = new System.Drawing.Point(6, 19);
            this.dGVHareket.Name = "dGVHareket";
            this.dGVHareket.ReadOnly = true;
            this.dGVHareket.Size = new System.Drawing.Size(734, 261);
            this.dGVHareket.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dGVHareket);
            this.groupBox1.Location = new System.Drawing.Point(22, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(746, 286);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stok Hareket";
            // 
            // lblIacNot
            // 
            this.lblIacNot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIacNot.Location = new System.Drawing.Point(98, 107);
            this.lblIacNot.Name = "lblIacNot";
            this.lblIacNot.Size = new System.Drawing.Size(231, 73);
            this.lblIacNot.TabIndex = 7;
            // 
            // lblIacNotu
            // 
            this.lblIacNotu.AutoSize = true;
            this.lblIacNotu.Location = new System.Drawing.Point(22, 107);
            this.lblIacNotu.Name = "lblIacNotu";
            this.lblIacNotu.Size = new System.Drawing.Size(70, 13);
            this.lblIacNotu.TabIndex = 8;
            this.lblIacNotu.Text = "İLAÇ NOTU :";
            // 
            // btnIlacDuzenle
            // 
            this.btnIlacDuzenle.Enabled = false;
            this.btnIlacDuzenle.Location = new System.Drawing.Point(401, 4);
            this.btnIlacDuzenle.Name = "btnIlacDuzenle";
            this.btnIlacDuzenle.Size = new System.Drawing.Size(75, 53);
            this.btnIlacDuzenle.TabIndex = 9;
            this.btnIlacDuzenle.Text = "İlaç &Düzenle";
            this.btnIlacDuzenle.UseCompatibleTextRendering = true;
            this.btnIlacDuzenle.UseVisualStyleBackColor = true;
            this.btnIlacDuzenle.Click += new System.EventHandler(this.btnIlacDuzenle_Click);
            // 
            // btnStokCikis
            // 
            this.btnStokCikis.Enabled = false;
            this.btnStokCikis.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStokCikis.ImageIndex = 1;
            this.btnStokCikis.ImageList = this.ımageList1;
            this.btnStokCikis.Location = new System.Drawing.Point(493, 130);
            this.btnStokCikis.Name = "btnStokCikis";
            this.btnStokCikis.Size = new System.Drawing.Size(75, 75);
            this.btnStokCikis.TabIndex = 10;
            this.btnStokCikis.Text = "Stok &Çıkış";
            this.btnStokCikis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStokCikis.UseCompatibleTextRendering = true;
            this.btnStokCikis.UseVisualStyleBackColor = false;
            this.btnStokCikis.Click += new System.EventHandler(this.btnStokCikis_Click);
            // 
            // lblKalanStogu
            // 
            this.lblKalanStogu.AutoSize = true;
            this.lblKalanStogu.Location = new System.Drawing.Point(12, 191);
            this.lblKalanStogu.Name = "lblKalanStogu";
            this.lblKalanStogu.Size = new System.Drawing.Size(80, 13);
            this.lblKalanStogu.TabIndex = 13;
            this.lblKalanStogu.Text = "KALAN STOK :";
            // 
            // lblKalanStok
            // 
            this.lblKalanStok.AutoSize = true;
            this.lblKalanStok.Location = new System.Drawing.Point(99, 191);
            this.lblKalanStok.Name = "lblKalanStok";
            this.lblKalanStok.Size = new System.Drawing.Size(0, 13);
            this.lblKalanStok.TabIndex = 14;
            // 
            // lblCari
            // 
            this.lblCari.AutoSize = true;
            this.lblCari.Location = new System.Drawing.Point(99, 24);
            this.lblCari.Name = "lblCari";
            this.lblCari.Size = new System.Drawing.Size(0, 13);
            this.lblCari.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "CARİ :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 517);
            this.Controls.Add(this.lblCari);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblKalanStok);
            this.Controls.Add(this.lblKalanStogu);
            this.Controls.Add(this.btnStokCikis);
            this.Controls.Add(this.btnIlacDuzenle);
            this.Controls.Add(this.lblIacNotu);
            this.Controls.Add(this.lblIacNot);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStokGiris);
            this.Controls.Add(this.txtIlacAdi);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.lblIlacAdi);
            this.Controls.Add(this.lblBarcode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "İlaç";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVHareket)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblIlacAdi;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.TextBox txtIlacAdi;
        private System.Windows.Forms.Button btnStokGiris;
        private System.Windows.Forms.DataGridView dGVHareket;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblIacNot;
        private System.Windows.Forms.Label lblIacNotu;
        private System.Windows.Forms.Button btnIlacDuzenle;
        private System.Windows.Forms.Button btnStokCikis;
        private System.Windows.Forms.Label lblKalanStogu;
        private System.Windows.Forms.Label lblKalanStok;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Label lblCari;
        private System.Windows.Forms.Label label2;
    }
}

