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
            textBoxColumn.DefaultCellStyle.Format = "yyyy-MM-dd";

            dgvCariHareket.Columns.Add(textBoxColumn);

            hModel = SqliteDataAccess.findHareketbyCariId(CariId);
           


            dgvCariHareket.DataSource = hModel;
        }
    }
}
