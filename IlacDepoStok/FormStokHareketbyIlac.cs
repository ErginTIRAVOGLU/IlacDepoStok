using IlacDepoStok.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IlacDepoStok
{
    public partial class FormStokHareketbyIlac : Form
    {
        public int ilac_id { get; set; }

        public FormStokHareketbyIlac()
        {
            InitializeComponent();
        }

        private void FormStokHareketbyIlac_Load(object sender, EventArgs e)
        {
            List<StokHareketModel> sModel = new List<StokHareketModel>();

            var culture = CultureInfo.CreateSpecificCulture("tr-TR");
            culture.NumberFormat.NumberGroupSeparator = " ";
            dGVStok.DefaultCellStyle.FormatProvider = culture;

            dGVStok.DataSource = null;
            dGVStok.Columns.Clear();


            DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "id";
            textBoxColumn.HeaderText = "No";
            textBoxColumn.Visible = false;
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "ilac_adi";            
            textBoxColumn.HeaderText = "Ilac";
            textBoxColumn.Width = 250;
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "barcode";
            textBoxColumn.HeaderText = "Barcode";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "cari_ad_soyad";
            textBoxColumn.HeaderText = "Cari";
            dGVStok.Columns.Add(textBoxColumn);


            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "depo_adi";
            textBoxColumn.HeaderText = "Depo";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "yon";
            textBoxColumn.HeaderText = "Yön";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "tarih";
            textBoxColumn.HeaderText = "Tarih";
            textBoxColumn.Width = 75;
            textBoxColumn.DefaultCellStyle.Format = "dd-MM-yyyy";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "adet";
            textBoxColumn.HeaderText = "Adet";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "fiyat";
            textBoxColumn.HeaderText = "Fiyat";
            textBoxColumn.DefaultCellStyle.Format = "C";
            dGVStok.Columns.Add(textBoxColumn);            

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "tutar";
            textBoxColumn.HeaderText = "Tutar";
            textBoxColumn.DefaultCellStyle.Format = "C2";
            dGVStok.Columns.Add(textBoxColumn);

            sModel = SqliteDataAccess.stokDurumubyIlacId(ilac_id);


            dGVStok.DataSource = sModel;
        }
    }
}
