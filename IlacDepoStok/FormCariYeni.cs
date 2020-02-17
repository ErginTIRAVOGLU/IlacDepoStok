using IlacDepoStok.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IlacDepoStok
{
    public partial class FormCariYeni : Form
    {
        public FormCariYeni()
        {
            InitializeComponent();
        }
        
        public int Kategori_Id { get; set; }
        public string Kategori_Adi { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            CariModel cariModel = new CariModel();
            if (lblCariID.Text != "")
            {
                cariModel.cari_id = int.Parse(lblCariID.Text);
                cariModel.cari_ad_soyad = txtCariAdi.Text;
                cariModel.cari_kategori_id = ((KategoriModel)(cmbKategoriAdi.SelectedItem)).cari_kategori_id;
                SqliteDataAccess.UpdateCari(cariModel);
            }
            else
            {
                cariModel.cari_ad_soyad= txtCariAdi.Text;
                cariModel.cari_kategori_id = Kategori_Id;
                SqliteDataAccess.SaveCari(cariModel);
            }
            this.Close();
        }

        private void FormCariYeni_Load(object sender, EventArgs e)
        {
            lblKategoriAdi.Text = Kategori_Adi;

            cmbKategoriAdi.DisplayMember = "cari_kategori_adi";
            cmbKategoriAdi.ValueMember = "cari_kategori_id";
            cmbKategoriAdi.DataSource = SqliteDataAccess.LoadCariKategoriler();
            var kategorisi = SqliteDataAccess.GetCariKategoribyId(Kategori_Id);
            cmbKategoriAdi.SelectedIndex = cmbKategoriAdi.FindStringExact(Kategori_Adi);
           // cmbKategoriAdi.set
        }
    }
}
