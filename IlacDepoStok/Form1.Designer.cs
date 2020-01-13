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
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblIlacAdi = new System.Windows.Forms.Label();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.txtIlacAdi = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.dGVHareket = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblIacNot = new System.Windows.Forms.Label();
            this.lblIacNotu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGVHareket)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(34, 24);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(58, 13);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "BARKOD :";
            // 
            // lblIlacAdi
            // 
            this.lblIlacAdi.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.lblIlacAdi.AutoSize = true;
            this.lblIlacAdi.Location = new System.Drawing.Point(35, 58);
            this.lblIlacAdi.Name = "lblIlacAdi";
            this.lblIlacAdi.Size = new System.Drawing.Size(57, 13);
            this.lblIlacAdi.TabIndex = 1;
            this.lblIlacAdi.Text = "İLAÇ ADI :";
            // 
            // txtBarkod
            // 
            this.txtBarkod.Location = new System.Drawing.Point(98, 21);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(156, 20);
            this.txtBarkod.TabIndex = 2;
            this.txtBarkod.TextChanged += new System.EventHandler(this.txtBarkod_TextChanged);
            this.txtBarkod.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyUp);
            // 
            // txtIlacAdi
            // 
            this.txtIlacAdi.Location = new System.Drawing.Point(98, 55);
            this.txtIlacAdi.Name = "txtIlacAdi";
            this.txtIlacAdi.Size = new System.Drawing.Size(156, 20);
            this.txtIlacAdi.TabIndex = 3;
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(401, 20);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 4;
            this.btnEkle.Text = "Stok Giriş";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // dGVHareket
            // 
            this.dGVHareket.AllowUserToAddRows = false;
            this.dGVHareket.AllowUserToDeleteRows = false;
            this.dGVHareket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVHareket.Location = new System.Drawing.Point(6, 19);
            this.dGVHareket.Name = "dGVHareket";
            this.dGVHareket.ReadOnly = true;
            this.dGVHareket.Size = new System.Drawing.Size(448, 180);
            this.dGVHareket.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dGVHareket);
            this.groupBox1.Location = new System.Drawing.Point(22, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 205);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stok Hareket";
            // 
            // lblIacNot
            // 
            this.lblIacNot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIacNot.Location = new System.Drawing.Point(98, 88);
            this.lblIacNot.Name = "lblIacNot";
            this.lblIacNot.Size = new System.Drawing.Size(231, 73);
            this.lblIacNot.TabIndex = 7;
            // 
            // lblIacNotu
            // 
            this.lblIacNotu.AutoSize = true;
            this.lblIacNotu.Location = new System.Drawing.Point(22, 88);
            this.lblIacNotu.Name = "lblIacNotu";
            this.lblIacNotu.Size = new System.Drawing.Size(70, 13);
            this.lblIacNotu.TabIndex = 8;
            this.lblIacNotu.Text = "İLAÇ NOTU :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 410);
            this.Controls.Add(this.lblIacNotu);
            this.Controls.Add(this.lblIacNot);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtIlacAdi);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.lblIlacAdi);
            this.Controls.Add(this.lblBarcode);
            this.Name = "Form1";
            this.Text = "İlaç Depo Stok";
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
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.DataGridView dGVHareket;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblIacNot;
        private System.Windows.Forms.Label lblIacNotu;
    }
}

