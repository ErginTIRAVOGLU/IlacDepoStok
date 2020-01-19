﻿using IlacDepoStok.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IlacDepoStok
{
    public partial class FormStokGiris : Form
    {
        public int IlacId { get; set; }
        public FormStokGiris()
        {
            InitializeComponent();
        }

        private void FormStokGiris_Load(object sender, EventArgs e)
        {
            cmbDepo.DisplayMember = "adi";
            cmbDepo.ValueMember = "id";
            cmbDepo.DataSource = SqliteDataAccess.LoadDepolar();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            HareketModel hModel = new HareketModel();
            hModel.adet = int.Parse(txtAdet.Text);
            hModel.ilac_id = IlacId;
            hModel.yon = "G";
           
            hModel.tarih =  dtpTarih.Value.ToString("yyyy-MM-dd");
            SqliteDataAccess.SaveHareket(hModel);
            this.Close();
        }

        
    }
}