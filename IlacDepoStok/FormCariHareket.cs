using IlacDepoStok.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IlacDepoStok
{
    public partial class FormCariHareket : Form
    {
        public int? CariId { get; set; }
        public FormCariHareket()
        {
            InitializeComponent();
        }

        private void FormCariHareket_Load(object sender, EventArgs e)
        {
            if (CariId != null)
            {
                var Cari = SqliteDataAccess.getCaribyCariId(CariId);
                lblCariId.Text = Cari.cari_id.ToString();
                lblCariAdi.Text = Cari.cari_ad_soyad;
                lblCariKategorisi.Text = Cari.cari_kategori_id.ToString();

                
                loadCariHareket();
            }
        }

        private void loadCariHareket()
        {
            List<HareketModel> hModel = new List<HareketModel>();
            
            var culture = CultureInfo.CreateSpecificCulture("tr-TR");
            culture.NumberFormat.NumberGroupSeparator = " ";
            dgvCariHareket.DefaultCellStyle.FormatProvider = culture;

            dgvCariHareket.DataSource = null;
            dgvCariHareket.Columns.Clear();


            DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "id";
            textBoxColumn.HeaderText = "No";
            textBoxColumn.Visible = false;
            dgvCariHareket.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "cari_id";
            textBoxColumn.HeaderText = "Cari No";
            textBoxColumn.Visible = false;
            dgvCariHareket.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "ilac_id";
            textBoxColumn.HeaderText = "Ilaç No";
            textBoxColumn.Visible = false;
            dgvCariHareket.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "cariadsoyad";
            textBoxColumn.HeaderText = "Cari Ad Soyad";
            textBoxColumn.Visible = false;
            dgvCariHareket.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "depo_id";
            textBoxColumn.HeaderText = "Depo No";
            textBoxColumn.Visible = false;
            dgvCariHareket.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "ilac_adi";
            textBoxColumn.HeaderText = "Ilac";
            textBoxColumn.Width = 250;
            dgvCariHareket.Columns.Add(textBoxColumn);

          

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "adet";
            textBoxColumn.HeaderText = "Adet";
            textBoxColumn.Width = 50;
            dgvCariHareket.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "yon";
            textBoxColumn.HeaderText = "Yön";
            textBoxColumn.Width = 50;
            dgvCariHareket.Columns.Add(textBoxColumn);


            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "depo_adi";
            textBoxColumn.HeaderText = "Depo";
            dgvCariHareket.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "tarih";
            textBoxColumn.HeaderText = "Tarih";
            textBoxColumn.Width = 75;
            textBoxColumn.DefaultCellStyle.Format = "d";            
            dgvCariHareket.Columns.Add(textBoxColumn);
            
            textBoxColumn = new DataGridViewTextBoxColumn();
            //CultureInfo ci = CultureInfo.CreateSpecificCulture("tr-TR");
            textBoxColumn.DataPropertyName = "fiyat";
            textBoxColumn.HeaderText = "Fiyat";
            //textBoxColumn.DefaultCellStyle.FormatProvider = ci;
            textBoxColumn.Width = 75;
            //textBoxColumn.ValueType = Type.GetType("System.Decimal");
            
           textBoxColumn.DefaultCellStyle.Format = "C";
            
            dgvCariHareket.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "tutar";
            textBoxColumn.HeaderText = "Tutar";
            textBoxColumn.Width = 75;
            textBoxColumn.DefaultCellStyle.Format = "C2";
            dgvCariHareket.Columns.Add(textBoxColumn);
            
            hModel = SqliteDataAccess.findHareketbyCariId(CariId);
           
            

            dgvCariHareket.DataSource = hModel;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dgvCariHareket.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvCariHareket.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvCariHareket.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells[0].Value);
                HareketModel hareket = SqliteDataAccess.getHareketbyId(int.Parse(cellValue));

                if (hareket.yon == "G")
                {


                    FormStokGiris frmStokGiris = new FormStokGiris();



                    Label ilacAdi = (Label)frmStokGiris.Controls["lblIlacAd"];
                    //ilacAdi.Text = hareket.ilac_adi;

                    TextBox ilacFiyat = (TextBox)frmStokGiris.Controls["txtFiyat"];
                    TextBox ilacAdet = (TextBox)frmStokGiris.Controls["txtAdet"];
                    TextBox hareketTutar = (TextBox)frmStokGiris.Controls["txtTutar"];

                    DateTimePicker tarih = (DateTimePicker)frmStokGiris.Controls["dtpTarih"];
                    //ilacFiyat.Text = hareket.fiyat.ToString();


                    frmStokGiris.CariId = hareket.cari_id;

                    var cari = SqliteDataAccess.findCaribyCariId(hareket.cari_id);
                    frmStokGiris.CariAdi = cari.cari_ad_soyad;


                    IlacModel ilac = SqliteDataAccess.findIlacbyId(hareket.ilac_id);

                    ilacAdi.Text = ilac.adi;
                    ilacFiyat.Text = hareket.fiyat.ToString();
                    ilacAdet.Text = hareket.adet.ToString();
                    hareketTutar.Text = string.Format(CultureInfo.CreateSpecificCulture("tr-TR"), "{0:C2}", hareket.tutar / 100);
                    tarih.Format = DateTimePickerFormat.Short;
                    // MessageBox.Show(hareket.tarih);
                    tarih.Value = DateTime.ParseExact(hareket.tarih, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    frmStokGiris.IlacId = ilac.id;
                    frmStokGiris.duzenleme = true;
                    frmStokGiris.hareket_depo_id = hareket.depo_id;
                    frmStokGiris.hareket_id = hareket.id;
                    frmStokGiris.ShowDialog();

                    loadCariHareket();
                    /*int kalanIlacStogu = kalanStokbyid(ilac.id);
                    lblKalanStok.Text = kalanIlacStogu.ToString();
                    */

                }
                else
                {


                    FormStokCikis frmStokCikis = new FormStokCikis();



                    Label ilacAdi = (Label)frmStokCikis.Controls["lblIlacAd"];
                    //ilacAdi.Text = hareket.ilac_adi;

                    TextBox ilacFiyat = (TextBox)frmStokCikis.Controls["txtFiyat"];
                    TextBox ilacAdet = (TextBox)frmStokCikis.Controls["txtAdet"];
                    TextBox hareketTutar = (TextBox)frmStokCikis.Controls["txtTutar"];

                    DateTimePicker tarih = (DateTimePicker)frmStokCikis.Controls["dtpTarih"];
                    //ilacFiyat.Text = hareket.fiyat.ToString();


                    frmStokCikis.CariId = hareket.cari_id;

                    var cari = SqliteDataAccess.findCaribyCariId(hareket.cari_id);
                    frmStokCikis.CariAdi = cari.cari_ad_soyad;


                    IlacModel ilac = SqliteDataAccess.findIlacbyId(hareket.ilac_id);

                    ilacAdi.Text = ilac.adi;
                    ilacFiyat.Text = hareket.fiyat.ToString();
                    ilacAdet.Text = hareket.adet.ToString();
                    hareketTutar.Text = string.Format(CultureInfo.CreateSpecificCulture("tr-TR"), "{0:C2}", hareket.tutar / 100);
                    tarih.Format = DateTimePickerFormat.Short;
                    // MessageBox.Show(hareket.tarih);
                    tarih.Value = DateTime.ParseExact(hareket.tarih, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    frmStokCikis.IlacId = ilac.id;
                    frmStokCikis.duzenleme = true;
                    frmStokCikis.hareket_depo_id = hareket.depo_id;
                    frmStokCikis.hareket_id = hareket.id;
                    frmStokCikis.ShowDialog();

                    loadCariHareket();
                    /* int kalanIlacStogu = kalanStokbyid(ilac.id);
                     lblKalanStok.Text = kalanIlacStogu.ToString();
                    */

                }

            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (dgvCariHareket.SelectedCells.Count > 0)
            {
                string yon = "C";
                string yonu = "ÇIKIŞ";
                int selectedrowindex = dgvCariHareket.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvCariHareket.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells[0].Value);
                HareketModel hareket = SqliteDataAccess.getHareketbyId(int.Parse(cellValue));
                if (hareket.yon == "C")
                {
                    yon = "G";
                    yonu = "GİRİŞ";
                }
                var result = MessageBox.Show(hareket.ilac_adi + " isimli İlacın Hareketi " + yonu + " Yönüne Değiştirilsin mi?", "Hareket Yönü Değiştirme Onayı", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    SqliteDataAccess.hareketYonDegistirbyId(hareket.id, yon);
                    loadCariHareket();

                    /*int kalanIlacStogu = kalanStokbyid(hareket.ilac_id);
                    lblKalanStok.Text = kalanIlacStogu.ToString();
                    */
                }
                else
                {

                }

            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvCariHareket.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvCariHareket.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvCariHareket.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells[0].Value);
                HareketModel hareket = SqliteDataAccess.getHareketbyId(int.Parse(cellValue));
                var result = MessageBox.Show(hareket.ilac_adi + " isimli İlaç Hareketi Silinsin mi?", "Silme Onayı", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    SqliteDataAccess.hareketSilbyId(hareket.id);
                    loadCariHareket();
                }
                else
                {

                }

            }
        }
    }
}
