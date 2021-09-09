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
    public partial class FormCari : Form
    {
        public FormCari()
        {
            InitializeComponent();
        }

        private void FormCari_Load(object sender, EventArgs e)
        {
            cariKategoriYukle();
            if (lstBoxKategori.SelectedItem != null)
            {
                int kategoriId = ((KategoriModel)(lstBoxKategori.SelectedItem)).cari_kategori_id;
                cariYukle(kategoriId);
            }
        }

        private void cariKategoriYukle()
        {
            lstBoxKategori.DisplayMember = "cari_kategori_adi";
            lstBoxKategori.ValueMember = "cari_kategori_id";
            lstBoxKategori.DataSource = SqliteDataAccess.LoadCariKategoriler();
        }
        private void cariKategoriYuklebyKategoriAdi(string kategoriAdi)
        {
            lstBoxKategori.DisplayMember = "cari_kategori_adi";
            lstBoxKategori.ValueMember = "cari_kategori_id";
            lstBoxKategori.DataSource = SqliteDataAccess.LoadCariKategorilerbyKategoriAdi(kategoriAdi);
        }
        private void cariYukle(int kategoriId)
        {
            lstBoxCari.DisplayMember = "cari_ad_soyad";
            lstBoxCari.ValueMember = "cari_id";
            lstBoxCari.DataSource = SqliteDataAccess.LoadCariler(kategoriId);
        }
        private void cariYuklebyCariAdi(string cariAdi)
        {
            lstBoxCari.DisplayMember = "cari_ad_soyad";
            lstBoxCari.ValueMember = "cari_id";
            lstBoxCari.DataSource = SqliteDataAccess.LoadCarilerbyCariAdi(cariAdi);
        }
        private void cariKategoirileYuklebyCariAdi(int kategoriId, string cariAdi)
        {
            lstBoxCari.DisplayMember = "cari_ad_soyad";
            lstBoxCari.ValueMember = "cari_id";
            lstBoxCari.DataSource = SqliteDataAccess.LoadCarilerKategoriilebyCariAdi(kategoriId, cariAdi);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FormKategoriYeni formKategoriYeni = new FormKategoriYeni();
            formKategoriYeni.ShowDialog();
            cariKategoriYukle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormKategoriYeni formKategoriYeni = new FormKategoriYeni();
            ((TextBox)(formKategoriYeni.Controls["txtCariKategoriAdi"])).Text = ((KategoriModel)(lstBoxKategori.SelectedItem)).cari_kategori_adi;
            ((Label)(formKategoriYeni.Controls["lblKategoriID"])).Text = ((KategoriModel)(lstBoxKategori.SelectedItem)).cari_kategori_id.ToString();

            formKategoriYeni.ShowDialog();
            cariKategoriYukle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Seçili Kategori'yi Silmek İstediğinizden Emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                int kategorId = ((KategoriModel)(lstBoxKategori.SelectedItem)).cari_kategori_id;


                SqliteDataAccess.cariKategoriSil(kategorId);
                cariKategoriYukle();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int cariKategoriId = 0;
            string cariKategoriAdi = "";

            if (lstBoxKategori.SelectedItem != null)
            {
                cariKategoriId = ((KategoriModel)(lstBoxKategori.SelectedItem)).cari_kategori_id;
                cariKategoriAdi = ((KategoriModel)(lstBoxKategori.SelectedItem)).cari_kategori_adi;

                FormCariYeni formCariYeni = new FormCariYeni();
                formCariYeni.Kategori_Adi = cariKategoriAdi;
                formCariYeni.Kategori_Id = cariKategoriId;
                ((Label)(formCariYeni.Controls["lblKategoriAdi"])).Visible = true;
                formCariYeni.ShowDialog();
                if (lstBoxKategori.SelectedItem != null)
                {
                    int kategoriId = ((KategoriModel)(lstBoxKategori.SelectedItem)).cari_kategori_id;
                    cariYukle(kategoriId);
                }
                //cariKategoriYukle();

            }
            else
            {
                MessageBox.Show("Önce \"Cari Kategori\" Seçiniz!");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormCariYeni formCariYeni = new FormCariYeni();
            formCariYeni.Kategori_Id = ((CariModel)(lstBoxCari.SelectedItem)).cari_kategori_id;
            formCariYeni.Kategori_Adi = ((KategoriModel)(lstBoxKategori.SelectedItem)).cari_kategori_adi;

            ((Label)(formCariYeni.Controls["lblCariID"])).Text = ((CariModel)(lstBoxCari.SelectedItem)).cari_id.ToString();
            ((TextBox)(formCariYeni.Controls["txtCariAdi"])).Text = ((CariModel)(lstBoxCari.SelectedItem)).cari_ad_soyad;
            ((Label)(formCariYeni.Controls["lblKategoriAdi"])).Text = ((CariModel)(lstBoxCari.SelectedItem)).cari_kategori_id.ToString();
            ((ComboBox)(formCariYeni.Controls["cmbKategoriAdi"])).Visible = true;
            ((TextBox)(formCariYeni.Controls["txtTelefon"])).Text = ((CariModel)(lstBoxCari.SelectedItem)).cari_telefon;
            ((TextBox)(formCariYeni.Controls["txtNot"])).Text = ((CariModel)(lstBoxCari.SelectedItem)).cari_not;
            ((TextBox)(formCariYeni.Controls["txtAdres"])).Text = ((CariModel)(lstBoxCari.SelectedItem)).cari_adres;
            formCariYeni.ShowDialog();
            if (lstBoxKategori.SelectedItem != null)
            {
                int kategoriId = ((KategoriModel)(lstBoxKategori.SelectedItem)).cari_kategori_id;
                cariYukle(kategoriId);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Seçili Cari'yi Silmek İstediğinizden Emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                int cariId = ((CariModel)(lstBoxCari.SelectedItem)).cari_id;


                SqliteDataAccess.cariSil(cariId);
                if (lstBoxKategori.SelectedItem != null)
                {
                    int kategoriId = ((KategoriModel)(lstBoxKategori.SelectedItem)).cari_kategori_id;
                    cariYukle(kategoriId);
                }
            }
        }

        private void lstBoxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxKategori.SelectedItem != null)
            {
                if (txtCariAdi.TextLength > 2)
                {
                    int kategoriId = ((KategoriModel)(lstBoxKategori.SelectedItem)).cari_kategori_id;
                    cariKategoirileYuklebyCariAdi(kategoriId, txtCariAdi.Text);

                }
                else
                {
                    int kategoriId = ((KategoriModel)(lstBoxKategori.SelectedItem)).cari_kategori_id;
                    cariYukle(kategoriId);
                }

            }
        }

        private void txtCariAdi_TextChanged(object sender, EventArgs e)
        {
            if (txtCariAdi.TextLength > 2)
            {
                cariYuklebyCariAdi(txtCariAdi.Text);
            }
            else
            {
                if (lstBoxKategori.SelectedItem != null)
                {
                    int kategoriId = ((KategoriModel)(lstBoxKategori.SelectedItem)).cari_kategori_id;
                    cariYukle(kategoriId);
                }
            }

        }

        private void txtKategoriAdi_TextChanged(object sender, EventArgs e)
        {
            if(txtKategoriAdi.TextLength>2)
            {
                cariKategoriYuklebyKategoriAdi(txtKategoriAdi.Text);
            }
            else
            {
                cariKategoriYukle();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frmAc = new Form1();
            int cariId = ((CariModel)(lstBoxCari.SelectedItem)).cari_id;
            frmAc.CariId = cariId;
            frmAc.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(lstBoxCari.SelectedItem!=null)
            { 
            FormCariHareket formCariHareket = new FormCariHareket();
            int cariId = ((CariModel)(lstBoxCari.SelectedItem)).cari_id;
            formCariHareket.CariId = cariId;
            formCariHareket.ShowDialog();
            }
            else
            {

            }
        }
    }
}
