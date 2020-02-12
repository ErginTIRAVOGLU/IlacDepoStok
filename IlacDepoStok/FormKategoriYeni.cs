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
    public partial class FormKategoriYeni : Form
    {
        public FormKategoriYeni()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            KategoriModel kategoriModel = new KategoriModel();
            if (lblKategoriID.Text != "")
            {
                kategoriModel.cari_kategori_adi = txtCariKategoriAdi.Text;
                kategoriModel.cari_kategori_id = int.Parse(lblKategoriID.Text);
                SqliteDataAccess.UpdateCariKategori(kategoriModel);
            }
            else
            {
                kategoriModel.cari_kategori_adi = txtCariKategoriAdi.Text;
                SqliteDataAccess.SaveCariKategori(kategoriModel);
            }
            this.Close();
        }
    }
}
