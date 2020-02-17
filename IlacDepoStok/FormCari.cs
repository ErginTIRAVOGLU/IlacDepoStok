﻿using IlacDepoStok.Data;
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
        private void cariYukle(int kategoriId)
        {
            lstBoxCari.DisplayMember = "cari_ad_soyad";
            lstBoxCari.ValueMember = "cari_id";
            lstBoxCari.DataSource = SqliteDataAccess.LoadCariler(kategoriId);
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
            int kategorId=((KategoriModel)(lstBoxKategori.SelectedItem)).cari_kategori_id;


            SqliteDataAccess.cariKategoriSil(kategorId);
            cariKategoriYukle();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int cariKategoriId = 0;
            string cariKategoriAdi = "";
            
            if (lstBoxKategori.SelectedItem!=null)
            {
                cariKategoriId = ((KategoriModel)(lstBoxKategori.SelectedItem)).cari_kategori_id;
                cariKategoriAdi = ((KategoriModel)(lstBoxKategori.SelectedItem)).cari_kategori_adi;

                FormCariYeni formCariYeni = new FormCariYeni();
                formCariYeni.Kategori_Adi = cariKategoriAdi;
                formCariYeni.Kategori_Id = cariKategoriId;
                formCariYeni.ShowDialog();
                cariKategoriYukle();
            }
            else
            {
                MessageBox.Show("Önce \"Cari Kategori\" Seçiniz!");
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void lstBoxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxKategori.SelectedItem != null)
            {
                int kategoriId = ((KategoriModel)(lstBoxKategori.SelectedItem)).cari_kategori_id;
                cariYukle(kategoriId);
            }
        }
    }
}
