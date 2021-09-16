using IlacDepoStok.Data;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IlacDepoStok
{
    public partial class FormStok : Form
    {
        public FormStok()
        {
            InitializeComponent();
        }

        private void btnStokListele_Click(object sender, EventArgs e)
        {
            StokListele();
        }

        private void StokListele()
        {
            List<StokModel> sModel = new List<StokModel>();

            dGVStok.DataSource = null;
            dGVStok.Columns.Clear();


            DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "id";
            textBoxColumn.HeaderText = "No";
            textBoxColumn.Visible = false;
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "adi";
            textBoxColumn.HeaderText = "Ilac";
            textBoxColumn.Width = 250;
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "barcode";
            textBoxColumn.HeaderText = "Barcode";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "notu";
            textBoxColumn.HeaderText = "Not";
            dGVStok.Columns.Add(textBoxColumn);


            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "dusukStok";
            textBoxColumn.HeaderText = "Düşük Stok";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "gireni";
            textBoxColumn.HeaderText = "Toplam Giren";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "cikani";
            textBoxColumn.HeaderText = "Toplam Çıkan";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "Stok";
            textBoxColumn.HeaderText = "Kalan Stok";
            dGVStok.Columns.Add(textBoxColumn);

            sModel = SqliteDataAccess.stokDurumu(((DepoModel)(cmbDepo.SelectedItem)).id);


            dGVStok.DataSource = sModel;
        }
        private void FormStok_Load(object sender, EventArgs e)
        {
            cmbDepo.DisplayMember = "adi";
            cmbDepo.ValueMember = "id";
            List<DepoModel> depolar = new List<DepoModel>();
            depolar.Add(new DepoModel() { adi = "Tüm Depolar", id = 0 });
            depolar.AddRange(SqliteDataAccess.LoadDepolar());
            cmbDepo.DataSource = depolar;
            cmbDepo.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Records";

                try
                {
                    for (int i = 1; i < dGVStok.Columns.Count + 1; i++)
                    {
                        worksheet.Cells[1, i] = dGVStok.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < dGVStok.Rows.Count - 0; i++)
                    {
                        for (int j = 0; j < dGVStok.Columns.Count; j++)
                        {
                            if (dGVStok.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dGVStok.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1] = "";
                            }
                        }
                    }

                    //Getting the location and file name of the excel to save from user. 
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveDialog.FilterIndex = 2;

                    if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        workbook.SaveAs(saveDialog.FileName);
                        MessageBox.Show("Export Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    app.Quit();
                    workbook = null;
                    worksheet = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dGVStok.SelectedCells.Count > 0)
            {
                int selectedrowindex = dGVStok.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dGVStok.Rows[selectedrowindex];
                int cellValue = int.Parse(selectedRow.Cells[0].Value.ToString());

                FormStokHareketbyIlac formStokHareketbyIlac = new FormStokHareketbyIlac();
                formStokHareketbyIlac.ilac_id = cellValue;
                formStokHareketbyIlac.Show();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (dGVStok.SelectedCells.Count > 0)
            {
                int selectedrowindex = dGVStok.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dGVStok.Rows[selectedrowindex];
                int cellValue = int.Parse(selectedRow.Cells[0].Value.ToString());
                string ilacAdi = selectedRow.Cells[1].Value.ToString();
                DialogResult result = MessageBox.Show("-> "+ilacAdi + " <- İsimli Bu İlacı Silmek İstediğinizden Emin misiniz ?", "İlaç Silme İzni", MessageBoxButtons.YesNo);
                if(result==DialogResult.Yes)
                {
                    SqliteDataAccess.DeleteHareketbyIlacId(cellValue);
                    SqliteDataAccess.DeleteIlac(cellValue);
                    StokListele();
                }
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (dGVStok.SelectedCells.Count > 0)
            {
                int selectedrowindex = dGVStok.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dGVStok.Rows[selectedrowindex];
                string cellValue = selectedRow.Cells[2].Value.ToString();

                FormYeniIlac formYeniIlac = new FormYeniIlac();
                System.Windows.Forms.TextBox edittxtBarkod = (System.Windows.Forms.TextBox)formYeniIlac.Controls["txtBarkod"];
                System.Windows.Forms.TextBox edittxtIlacAdi = (System.Windows.Forms.TextBox)formYeniIlac.Controls["txtIlacAdi"];
                System.Windows.Forms.TextBox edittxtIlacNotu = (System.Windows.Forms.TextBox)formYeniIlac.Controls["txtIlacNotu"];
                System.Windows.Forms.TextBox edittxtIlacDusukStok = (System.Windows.Forms.TextBox)formYeniIlac.Controls["txtDusukStok"];
                System.Windows.Forms.TextBox edittxtIlacFiyat = (System.Windows.Forms.TextBox)formYeniIlac.Controls["txtFiyat"];

                IlacModel ilac = SqliteDataAccess.findIlacbyBarkod(cellValue);

                edittxtBarkod.Text = ilac.barcode;
                formYeniIlac.lblIdsi = int.Parse(ilac.id.ToString());
                edittxtIlacAdi.Text = ilac.adi;
                edittxtIlacNotu.Text = ilac.notu;
                int ilacFiyat = 0;
                int.TryParse(ilac.fiyat.ToString(), out ilacFiyat);
                edittxtIlacFiyat.Text = ilacFiyat.ToString();
                int dusukStok = 0;
                int.TryParse(ilac.dusukStok.ToString(), out dusukStok);
                edittxtIlacDusukStok.Text = dusukStok.ToString();
                formYeniIlac.ShowDialog();
            }
        }
    }
}
