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
            // FormStok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 450);
            this.Controls.Add(this.btnStokListele);
            this.Controls.Add(this.dGVStok);
            this.Name = "FormStok";
            this.Text = "Stok";
            ((System.ComponentModel.ISupportInitialize)(this.dGVStok)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVStok;
        private System.Windows.Forms.Button btnStokListele;
    }
}