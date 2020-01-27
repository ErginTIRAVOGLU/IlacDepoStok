using IlacDepoStok.Data;
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
    public partial class FormStok : Form
    {
        public FormStok()
        {
            InitializeComponent();
        }

        private void btnStokListele_Click(object sender, EventArgs e)
        {
            List<StokModel> sModel = new List<StokModel>();
            //dGVStok.DataSource = sModel;
            dGVStok.DataSource = null;
            dGVStok.Columns.Clear();
            //List<IlacModel> ilaclar = new List<IlacModel>();
            //ilaclar = SqliteDataAccess.LoadIlaclar();

            DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "id";
            textBoxColumn.HeaderText = "No";
            textBoxColumn.Visible = false;
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "adi";
            textBoxColumn.HeaderText = "Ilac";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "barcode";
            textBoxColumn.HeaderText = "Barcode";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "notu";
            textBoxColumn.HeaderText = "Not";
            dGVStok.Columns.Add(textBoxColumn);


            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "dusukStok";
            textBoxColumn.HeaderText = "Düşük Stok";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "gireni";
            textBoxColumn.HeaderText = "Toplam Giren";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "cikani";
            textBoxColumn.HeaderText = "Toplam Çıkan";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "Stok";
            textBoxColumn.HeaderText = "Kalan Stok";
            dGVStok.Columns.Add(textBoxColumn);

            sModel = SqliteDataAccess.stokDurumu();


            dGVStok.DataSource = sModel;
        }
    }
}
