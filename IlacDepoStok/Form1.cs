using IlacDepoStok.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IlacDepoStok
{
    public partial class Form1 : Form
    {
        public int? CariId { get; set; }
        public Form1()
        {
            InitializeComponent();
            dGVHareket.AutoGenerateColumns = false;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
           if(CariId!=null)
            {
                lblCari.Text = SqliteDataAccess.getCaribyCariId(CariId).cari_ad_soyad;
            }
            dateTimePicker1.Value = DateTime.Now;
            loadIlacList(dateTimePicker1.Value);
            
        }

        public int ilacid { get; set; }

        private void txtBarkod_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if(!String.IsNullOrEmpty(txtBarkod.Text))
                {
                    ilacBul(txtBarkod.Text);
                }
            }
        }

        private void ilacBul(string BarcodeNo)
        {
            IlacModel ilac = barkodAra(BarcodeNo);
            int kalanIlacStogu = kalanStok(BarcodeNo);
            if (ilac != null)
            {
                btnStokGiris.Enabled = true;
                btnStokCikis.Enabled = true;
                txtIlacAdi.Text = ilac.adi;
                lblIacNot.Text = ilac.notu;
                ilacid = ilac.id;
                lblKalanStok.Text = kalanIlacStogu.ToString();
                btnIlacDuzenle.Enabled = true;

                string value = ilac.fiyat.ToString().Replace(".", "").Replace("₺", "").Replace(",", "").TrimStart('0');
                decimal deger;

                try
                {
                    deger = (decimal.Parse(value));
                    lblFiyat.Text = string.Format(CultureInfo.CreateSpecificCulture("tr-TR"), "{0:C2}", deger / 100);
                }
                catch
                {


                }
                //lblFiyat.Text = ilac.fiyat.ToString().Replace(".", "").Replace("₺", "").Replace(",", "").TrimStart('0');
                /*List<HareketModel> ilacHareket = new List<HareketModel>();
                ilacHareket = SqliteDataAccess.findHareketbyIlacId(ilac.id);
                dGVHareket.DataSource = ilacHareket;*/
            }
            else
            {
                btnStokGiris.Enabled = false;
                btnStokCikis.Enabled = false;
                txtIlacAdi.Text = "";
                lblIacNot.Text = "İlaç Kaydı Bulunamadı.";
                lblKalanStok.Text = "";
                btnIlacDuzenle.Enabled = false;
                /*List<HareketModel> ilacHareket = new List<HareketModel>();
                dGVHareket.DataSource = ilacHareket;*/

                DialogResult dialogResult = new DialogResult();
                dialogResult = MessageBox.Show("Bu Barkod Numarasına Kayıtlı Bir İlaç Bulunamadı. Yeni İlaç Kayıt Etmek İster misiniz?", "Yeni İlaç Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    FormYeniIlac formYeniIlac = new FormYeniIlac();
                    TextBox newtxtBarkod = (TextBox)formYeniIlac.Controls["txtBarkod"];
                    TextBox newtxtIlacAdi = (TextBox)formYeniIlac.Controls["txtIlacAdi"];
                    TextBox newtxtIlacFiyat = (TextBox)formYeniIlac.Controls["txtFiyat"];
                    newtxtBarkod.Text = txtBarkod.Text;
                    newtxtIlacAdi.Select();
                    formYeniIlac.ShowDialog();
                    ilacBul(newtxtBarkod.Text);
                }

            }
        }

        private IlacModel barkodAra(string barkod)
        {
            IlacModel ilac = SqliteDataAccess.findIlacbyBarkod(barkod);
            return ilac;
        }
        private int kalanStok(string barkod)
        {
            int ilacStok = SqliteDataAccess.findIlacStokbyBarkod(barkod);
            return ilacStok;
        }
        private int kalanStokbyid(int id)
        {
            int ilacStok = SqliteDataAccess.findIlacStokbyid(id);
            return ilacStok;
        }
        private void loadIlacList(DateTime listeTarihi)
        {
            List<HareketModel> hModel = new List<HareketModel>();
            
            dGVHareket.DataSource = null;
            dGVHareket.Columns.Clear();
         

            DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "id";
            textBoxColumn.HeaderText = "No";
            textBoxColumn.Visible = false;
            dGVHareket.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "ilac_adi";
            textBoxColumn.HeaderText = "Ilac";
            textBoxColumn.Width = 250;
            dGVHareket.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "cariadsoyad";
            textBoxColumn.HeaderText = "Cari";
            textBoxColumn.Width = 150;
            dGVHareket.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "adet";
            textBoxColumn.HeaderText = "Adet";
            textBoxColumn.Width = 50;
            dGVHareket.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "yon";
            textBoxColumn.HeaderText = "Yön";
            textBoxColumn.Width = 50;
            dGVHareket.Columns.Add(textBoxColumn);


            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "depo_adi";
            textBoxColumn.HeaderText = "Depo";
            dGVHareket.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "tarih";
            textBoxColumn.HeaderText = "Tarih";
            textBoxColumn.Width = 75;
            textBoxColumn.DefaultCellStyle.Format = "dd-MM-yyyy";

            dGVHareket.Columns.Add(textBoxColumn);
            
            hModel = SqliteDataAccess.findHareketbyTarih(listeTarihi.ToString("yyyy-MM-dd"));
            //hModel = SqliteDataAccess.findHareketbyTarih(DateTime.Now.ToString("yyyy-MM-dd"));


            dGVHareket.DataSource = hModel;
        }
 
        private void txtBarkod_TextChanged(object sender, EventArgs e)
        {
            btnIlacDuzenle.Enabled = false;
            btnStokGiris.Enabled = false;
            btnStokCikis.Enabled = false;
            txtIlacAdi.Text = "";
            lblIacNot.Text = "";
            lblKalanStok.Text = "";
            ilacid = 0;
        }

        private void btnIlacDuzenle_Click(object sender, EventArgs e)
        {
            FormYeniIlac formYeniIlac = new FormYeniIlac();
            TextBox edittxtBarkod = (TextBox)formYeniIlac.Controls["txtBarkod"];
            TextBox edittxtIlacAdi = (TextBox)formYeniIlac.Controls["txtIlacAdi"];
            TextBox edittxtIlacNotu = (TextBox)formYeniIlac.Controls["txtIlacNotu"];
            TextBox edittxtIlacDusukStok = (TextBox)formYeniIlac.Controls["txtDusukStok"];
            TextBox edittxtIlacFiyat = (TextBox)formYeniIlac.Controls["txtFiyat"];

            IlacModel ilac = SqliteDataAccess.findIlacbyBarkod(txtBarkod.Text);

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
            ilacBul(ilac.barcode);
        }

        private void btnStokGiris_Click(object sender, EventArgs e)
        {
            FormStokGiris frmStokGiris = new FormStokGiris();
            Label ilacAdi = (Label)frmStokGiris.Controls["lblIlacAd"];
            TextBox ilacFiyat = (TextBox)frmStokGiris.Controls["txtFiyat"];
            frmStokGiris.CariId = CariId;
            
            var cari = SqliteDataAccess.findCaribyCariId(CariId);
            frmStokGiris.CariAdi = cari.cari_ad_soyad;

            IlacModel ilac = SqliteDataAccess.findIlacbyBarkod(txtBarkod.Text);

            ilacAdi.Text = ilac.adi;
            ilacFiyat.Text = ilac.fiyat.ToString();
            frmStokGiris.IlacId = ilacid;
            frmStokGiris.duzenleme = false;
            frmStokGiris.ShowDialog();
            loadIlacList(dateTimePicker1.Value);
            int kalanIlacStogu = kalanStok(txtBarkod.Text);
            lblKalanStok.Text = kalanIlacStogu.ToString();
        }

        private void btnStokCikis_Click(object sender, EventArgs e)
        {
            FormStokCikis frmStokCikis = new FormStokCikis();
            Label ilacAdi = (Label)frmStokCikis.Controls["lblIlacAd"];
            TextBox ilacFiyat = (TextBox)frmStokCikis.Controls["txtFiyat"];
            frmStokCikis.CariId = CariId;

            var cari = SqliteDataAccess.findCaribyCariId(CariId);
            frmStokCikis.CariAdi = cari.cari_ad_soyad;

            IlacModel ilac = SqliteDataAccess.findIlacbyBarkod(txtBarkod.Text);

            ilacAdi.Text = ilac.adi;
            ilacFiyat.Text = ilac.fiyat.ToString();
            frmStokCikis.IlacId = ilacid;
            frmStokCikis.ShowDialog();
            loadIlacList(dateTimePicker1.Value);
            int kalanIlacStogu = kalanStok(txtBarkod.Text);
            lblKalanStok.Text = kalanIlacStogu.ToString();
        }

        private void btnDepolar_Click(object sender, EventArgs e)
        {
            FormDepo formDepo = new FormDepo();
            formDepo.ShowDialog();
        }

        private void btnStokGor_Click(object sender, EventArgs e)
        {
            FormStok formStok = new FormStok();
            formStok.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dGVHareket.SelectedCells.Count > 0)
            {
                int selectedrowindex = dGVHareket.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dGVHareket.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells[0].Value);
                HareketModel hareket = SqliteDataAccess.getHareketbyId(int.Parse(cellValue));
                var result = MessageBox.Show(hareket.ilac_adi + " isimli İlaç Hareketi Silinsin mi?", "Silme Onayı", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    SqliteDataAccess.hareketSilbyId(hareket.id);
                    loadIlacList(dateTimePicker1.Value);
                }
                else
                {

                }

            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dGVHareket.SelectedCells.Count > 0)
            {
                int selectedrowindex = dGVHareket.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dGVHareket.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells[0].Value);
                HareketModel hareket = SqliteDataAccess.getHareketbyId(int.Parse(cellValue));
                 
                if(hareket.yon=="G")
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
                    
                    tarih.Value = DateTime.Parse(hareket.tarih);
                    frmStokGiris.IlacId = ilac.id;
                    frmStokGiris.duzenleme = true;
                    frmStokGiris.hareket_depo_id = hareket.depo_id;
                    frmStokGiris.hareket_id = hareket.id;
                    frmStokGiris.ShowDialog();
                   
                    loadIlacList(dateTimePicker1.Value);
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

                    tarih.Value = DateTime.Parse(hareket.tarih);
                    frmStokCikis.IlacId = ilac.id;
                    frmStokCikis.duzenleme = true;
                    frmStokCikis.hareket_depo_id = hareket.depo_id;
                    frmStokCikis.hareket_id = hareket.id;
                    frmStokCikis.ShowDialog();

                    loadIlacList(dateTimePicker1.Value);
                   /* int kalanIlacStogu = kalanStokbyid(ilac.id);
                    lblKalanStok.Text = kalanIlacStogu.ToString();
                   */

                }

            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            loadIlacList(dateTimePicker1.Value);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (dGVHareket.SelectedCells.Count > 0)
            {
                string yon = "C";
                string yonu = "ÇIKIŞ"; 
                int selectedrowindex = dGVHareket.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dGVHareket.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells[0].Value);
                HareketModel hareket = SqliteDataAccess.getHareketbyId(int.Parse(cellValue));
                if(hareket.yon=="C")
                {
                    yon = "G";
                    yonu = "GİRİŞ";
                }
                var result = MessageBox.Show(hareket.ilac_adi + " isimli İlacın Hareketi "+ yonu +" Yönüne Değiştirilsin mi?", "Hareket Yönü Değiştirme Onayı", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    SqliteDataAccess.hareketYonDegistirbyId(hareket.id,yon);
                    loadIlacList(dateTimePicker1.Value);
 
                    /*int kalanIlacStogu = kalanStokbyid(hareket.ilac_id);
                    lblKalanStok.Text = kalanIlacStogu.ToString();
                    */
                }
                else
                {

                }

            }
        }
    }
}
