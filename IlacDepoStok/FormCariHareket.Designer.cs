namespace IlacDepoStok
{
    partial class FormCariHareket
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCariId = new System.Windows.Forms.Label();
            this.lblCariAdi = new System.Windows.Forms.Label();
            this.lblCariKategorisi = new System.Windows.Forms.Label();
            this.dgvCariHareket = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCariHareket)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cari ID : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cari Adı Soyadı : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cari Kategori : ";
            // 
            // lblCariId
            // 
            this.lblCariId.AutoSize = true;
            this.lblCariId.Location = new System.Drawing.Point(105, 23);
            this.lblCariId.Name = "lblCariId";
            this.lblCariId.Size = new System.Drawing.Size(0, 13);
            this.lblCariId.TabIndex = 3;
            // 
            // lblCariAdi
            // 
            this.lblCariAdi.AutoSize = true;
            this.lblCariAdi.Location = new System.Drawing.Point(105, 43);
            this.lblCariAdi.Name = "lblCariAdi";
            this.lblCariAdi.Size = new System.Drawing.Size(0, 13);
            this.lblCariAdi.TabIndex = 4;
            // 
            // lblCariKategorisi
            // 
            this.lblCariKategorisi.AutoSize = true;
            this.lblCariKategorisi.Location = new System.Drawing.Point(105, 66);
            this.lblCariKategorisi.Name = "lblCariKategorisi";
            this.lblCariKategorisi.Size = new System.Drawing.Size(0, 13);
            this.lblCariKategorisi.TabIndex = 5;
            // 
            // dgvCariHareket
            // 
            this.dgvCariHareket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCariHareket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCariHareket.Location = new System.Drawing.Point(12, 115);
            this.dgvCariHareket.Name = "dgvCariHareket";
            this.dgvCariHareket.Size = new System.Drawing.Size(776, 323);
            this.dgvCariHareket.TabIndex = 6;
            // 
            // FormCariHareket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvCariHareket);
            this.Controls.Add(this.lblCariKategorisi);
            this.Controls.Add(this.lblCariAdi);
            this.Controls.Add(this.lblCariId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormCariHareket";
            this.Text = "Cari Hareket";
            this.Load += new System.EventHandler(this.FormCariHareket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCariHareket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCariId;
        private System.Windows.Forms.Label lblCariAdi;
        private System.Windows.Forms.Label lblCariKategorisi;
        private System.Windows.Forms.DataGridView dgvCariHareket;
    }
}