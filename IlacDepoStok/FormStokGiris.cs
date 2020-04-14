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
    public partial class FormStokGiris : Form
    {
        public int IlacId { get; set; }
        public int? CariId { get; set; }
        public string CariAdi { get; set; }

        public FormStokGiris()
        {
            InitializeComponent();
        }

        private void FormStokGiris_Load(object sender, EventArgs e)
        {
            cmbDepo.DisplayMember = "adi";
            cmbDepo.ValueMember = "id";
            cmbDepo.DataSource = SqliteDataAccess.LoadDepolar();
            lblCariAdi.Text = CariAdi;            
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
            hModel.depo_id = ((DepoModel)(cmbDepo.SelectedItem)).id;
            hModel.cari_id = int.Parse(CariId.ToString());

            int fiyat = 0;
            if (txtFiyat.Text.Contains(','))
            {
                fiyat = int.Parse(txtFiyat.Text.Replace(",", ""));
            }
            else
            {
                fiyat = int.Parse(txtFiyat.Text) * 100;
            }
            hModel.fiyat = fiyat;

            int tutar = 0;
            if (txtTutar.Text.Contains(','))
            {
                //MessageBox.Show(txtTutar.Text.IndexOf(',') + " . " + txtTutar.TextLength);
                if (txtTutar.Text.IndexOf(',') == txtTutar.TextLength - 2)
                {
                    txtTutar.Text = txtTutar.Text + "0";
                }
                else if (txtTutar.TextLength - txtTutar.Text.IndexOf(',') > 3)
                {
                    txtTutar.Text = txtTutar.Text.Substring(0, txtTutar.Text.IndexOf(',') + 3);
                }

                tutar = int.Parse(txtTutar.Text.Replace(",", ""));
            }
            else
            {
                tutar = int.Parse(txtTutar.Text) * 100;
            }
            hModel.tutar = tutar;


            hModel.tarih = DateTime.Today.ToString("yyyy-MM-dd");// dtpTarih.Value.ToString("yyyy-MM-dd");
            SqliteDataAccess.SaveHareket(hModel);
            this.Close();
        }
        private void txtAdet_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTutar.Text = (decimal.Parse(txtAdet.Text) * decimal.Parse(txtFiyat.Text)).ToString();
            }
            catch
            {


            }

        }

        private void txtFiyat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTutar.Text = (decimal.Parse(txtAdet.Text) * decimal.Parse(txtFiyat.Text)).ToString();
            }
            catch
            {


            }

        }

    }
}
