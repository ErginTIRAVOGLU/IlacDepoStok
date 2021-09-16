
namespace IlacDepoStok
{
    partial class FormStokHareketbyIlac
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
            ((System.ComponentModel.ISupportInitialize)(this.dGVStok)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVStok
            // 
            this.dGVStok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVStok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVStok.Location = new System.Drawing.Point(12, 39);
            this.dGVStok.Name = "dGVStok";
            this.dGVStok.Size = new System.Drawing.Size(1156, 541);
            this.dGVStok.TabIndex = 1;
            // 
            // FormStokHareketbyIlac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 592);
            this.Controls.Add(this.dGVStok);
            this.Name = "FormStokHareketbyIlac";
            this.Text = "Stok İlaç Hareketi";
            this.Load += new System.EventHandler(this.FormStokHareketbyIlac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVStok)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVStok;
    }
}