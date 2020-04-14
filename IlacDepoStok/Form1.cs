﻿using IlacDepoStok.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            loadIlacList();
            
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

        private void loadIlacList()
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
            textBoxColumn.DefaultCellStyle.Format = "yyyy-MM-dd";

            dGVHareket.Columns.Add(textBoxColumn);
            hModel = SqliteDataAccess.findHareketbyTarih(DateTime.Now.ToString("yyyy-MM-dd"));
           

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
             
            IlacModel ilac = SqliteDataAccess.findIlacbyBarkod(txtBarkod.Text);

            edittxtBarkod.Text = ilac.barcode;
            formYeniIlac.lblIdsi = int.Parse(ilac.id.ToString());
            edittxtIlacAdi.Text = ilac.adi;
            edittxtIlacNotu.Text = ilac.notu;
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
            frmStokGiris.CariId = CariId;
            
            var cari = SqliteDataAccess.findCaribyCariId(CariId);
            frmStokGiris.CariAdi = cari.cari_ad_soyad;

            IlacModel ilac = SqliteDataAccess.findIlacbyBarkod(txtBarkod.Text);

            ilacAdi.Text = ilac.adi;
            frmStokGiris.IlacId = ilacid;
            frmStokGiris.ShowDialog();
            loadIlacList();
            int kalanIlacStogu = kalanStok(txtBarkod.Text);
            lblKalanStok.Text = kalanIlacStogu.ToString();
        }

        private void btnStokCikis_Click(object sender, EventArgs e)
        {
            FormStokCikis frmStokCikis = new FormStokCikis();
            Label ilacAdi = (Label)frmStokCikis.Controls["lblIlacAd"];
            frmStokCikis.CariId = CariId;

            var cari = SqliteDataAccess.findCaribyCariId(CariId);
            frmStokCikis.CariAdi = cari.cari_ad_soyad;

            IlacModel ilac = SqliteDataAccess.findIlacbyBarkod(txtBarkod.Text);

            ilacAdi.Text = ilac.adi;
            frmStokCikis.IlacId = ilacid;
            frmStokCikis.ShowDialog();
            loadIlacList();
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
    }
}
