namespace IlacDepoStok
{
    partial class FormStok
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
            this.dGVStok = new System.Windows.Forms.DataGridView();
            this.btnStokListele = new System.Windows.Forms.Button();
            this.cmbDepo = new System.Windows.Forms.ComboBox();
            this.lblDepo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVStok)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVStok
            // 
            this.dGVStok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVStok.Location = new System.Drawing.Point(12, 66);
            this.dGVStok.Name = "dGVStok";
            this.dGVStok.Size = new System.Drawing.Size(977, 372);
            this.dGVStok.TabIndex = 0;
            // 
            // btnStokListele
            // 
            this.btnStokListele.Location = new System.Drawing.Point(914, 37);
            this.btnStokListele.Name = "btnStokListele";
            this.btnStokListele.Size = new System.Drawing.Size(75, 23);
            this.btnStokListele.TabIndex = 3;
            this.btnStokListele.Text = "Stok Listele";
            this.btnStokListele.UseVisualStyleBackColor = true;
            this.btnStokListele.Click += new System.EventHandler(this.btnStokListele_Click);
            // 
            // cmbDepo
            // 
            this.cmbDepo.FormattingEnabled = true;
            this.cmbDepo.Location = new System.Drawing.Point(788, 39);
            this.cmbDepo.Name = "cmbDepo";
            this.cmbDepo.Size = new System.Drawing.Size(120, 21);
            this.cmbDepo.TabIndex = 13;
            // 
            // lblDepo
            // 
            this.lblDepo.AutoSize = true;
            this.lblDepo.Location = new System.Drawing.Point(739, 42);
            this.lblDepo.Name = "lblDepo";
            this.lblDepo.Size = new System.Drawing.Size(43, 13);
            this.lblDepo.TabIndex = 12;
            this.lblDepo.Text = "DEPO :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(534, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormStok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbDepo);
            this.Controls.Add(this.lblDepo);
            this.Controls.Add(this.btnStokListele);
            this.Controls.Add(this.dGVStok);
            this.Name = "FormStok";
            this.Text = "Stok";
            this.Load += new System.EventHandler(this.FormStok_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVStok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVStok;
        private System.Windows.Forms.Button btnStokListele;
        private System.Windows.Forms.ComboBox cmbDepo;
        private System.Windows.Forms.Label lblDepo;
        private System.Windows.Forms.Button button1;
    }
}