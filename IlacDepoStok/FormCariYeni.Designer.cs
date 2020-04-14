namespace IlacDepoStok
{
    partial class FormCariYeni
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtCariAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblKategoriAdi = new System.Windows.Forms.Label();
            this.lblCariID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbKategoriAdi = new System.Windows.Forms.ComboBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNot = new System.Windows.Forms.TextBox();
            this.lblNot = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(232, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCariAdi
            // 
            this.txtCariAdi.Location = new System.Drawing.Point(88, 40);
            this.txtCariAdi.Name = "txtCariAdi";
            this.txtCariAdi.Size = new System.Drawing.Size(100, 20);
            this.txtCariAdi.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Adı Soyadı : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kategori Adı : ";
            // 
            // lblKategoriAdi
            // 
            this.lblKategoriAdi.AutoSize = true;
            this.lblKategoriAdi.Location = new System.Drawing.Point(92, 67);
            this.lblKategoriAdi.Name = "lblKategoriAdi";
            this.lblKategoriAdi.Size = new System.Drawing.Size(0, 13);
            this.lblKategoriAdi.TabIndex = 7;
            this.lblKategoriAdi.Visible = false;
            // 
            // lblCariID
            // 
            this.lblCariID.AutoSize = true;
            this.lblCariID.Location = new System.Drawing.Point(92, 24);
            this.lblCariID.Name = "lblCariID";
            this.lblCariID.Size = new System.Drawing.Size(0, 13);
            this.lblCariID.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cari ID : ";
            // 
            // cmbKategoriAdi
            // 
            this.cmbKategoriAdi.FormattingEnabled = true;
            this.cmbKategoriAdi.Location = new System.Drawing.Point(88, 64);
            this.cmbKategoriAdi.Name = "cmbKategoriAdi";
            this.cmbKategoriAdi.Size = new System.Drawing.Size(121, 21);
            this.cmbKategoriAdi.TabIndex = 10;
            this.cmbKategoriAdi.Visible = false;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(88, 91);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(138, 20);
            this.txtTelefon.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Telefon : ";
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(88, 117);
            this.txtAdres.Multiline = true;
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(138, 75);
            this.txtAdres.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Adres : ";
            // 
            // txtNot
            // 
            this.txtNot.Location = new System.Drawing.Point(277, 43);
            this.txtNot.Multiline = true;
            this.txtNot.Name = "txtNot";
            this.txtNot.Size = new System.Drawing.Size(242, 149);
            this.txtNot.TabIndex = 15;
            // 
            // lblNot
            // 
            this.lblNot.AutoSize = true;
            this.lblNot.Location = new System.Drawing.Point(274, 24);
            this.lblNot.Name = "lblNot";
            this.lblNot.Size = new System.Drawing.Size(33, 13);
            this.lblNot.TabIndex = 16;
            this.lblNot.Text = "Not : ";
            // 
            // FormCariYeni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 305);
            this.Controls.Add(this.lblNot);
            this.Controls.Add(this.txtNot);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbKategoriAdi);
            this.Controls.Add(this.lblCariID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblKategoriAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCariAdi);
            this.Controls.Add(this.label1);
            this.Name = "FormCariYeni";
            this.Text = "Yeni Cari";
            this.Load += new System.EventHandler(this.FormCariYeni_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCariAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblKategoriAdi;
        private System.Windows.Forms.Label lblCariID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbKategoriAdi;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNot;
        private System.Windows.Forms.Label lblNot;
    }
}