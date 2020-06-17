using IlacDepoStok.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IlacDepoStok
{
    public partial class FormStokCikis : Form
    {
        public int IlacId { get; set; }
        public int? CariId { get; set; }
        public string CariAdi { get; set; }

        public FormStokCikis()
        {
            InitializeComponent();
        }

        private void FormStokCikis_Load(object sender, EventArgs e)
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
            hModel.yon = "C";
            hModel.depo_id = ((DepoModel)(cmbDepo.SelectedItem)).id;
            hModel.cari_id = int.Parse(CariId.ToString());

            string fiyat = txtFiyat.Text.Replace(".", "").Replace("₺", "").Replace(",", "").TrimStart('0');

            hModel.fiyat = int.Parse(fiyat);

            string tutar = txtTutar.Text.Replace(".", "").Replace("₺", "").Replace(",", "").TrimStart('0');

            hModel.tutar = int.Parse(tutar);


            hModel.tarih = dtpTarih.Value.ToString("yyyy-MM-dd");//DateTime.Today.ToString("yyyy-MM-dd");// 
            SqliteDataAccess.SaveHareket(hModel);
            this.Close();
        }

        private void txtAdet_TextChanged(object sender, EventArgs e)
        {
            string value = txtFiyat.Text.Replace(".", "")
               .Replace("₺", "").Replace(",", "").TrimStart('0');
            decimal deger;

            try
            {
                deger = (decimal.Parse(txtAdet.Text) * decimal.Parse(value));
                txtTutar.Text = string.Format(CultureInfo.CreateSpecificCulture("tr-TR"), "{0:C2}", deger / 100);
            }
            catch
            {


            }

        }

        private void txtFiyat_TextChanged(object sender, EventArgs e)
        {
            //Remove previous formatting, or the decimal check will fail including leading zeros
            string value = txtFiyat.Text.Replace(".", "")
                .Replace("₺", "").Replace(",", "").TrimStart('0');
            decimal ul;
            decimal deger;
            //Check we are indeed handling a number
            if (decimal.TryParse(value, out ul))
            {
                ul /= 100;
                //Unsub the event so we don't enter a loop
                txtFiyat.TextChanged -= txtFiyat_TextChanged;
                //Format the text as currency



                txtFiyat.Text = string.Format(CultureInfo.CreateSpecificCulture("tr-TR"), "{0:C2}", ul);
                //txtFiyat.Text = string.Format("{0:C2}", ul);
                txtFiyat.TextChanged += txtFiyat_TextChanged;
                txtFiyat.Select(txtFiyat.Text.Length, 0);
            }
            bool goodToGo = TextisValid(txtFiyat.Text);
            btnKaydet.Enabled = goodToGo;
            if (!goodToGo)
            {
                txtFiyat.Text = "0.00₺";
                txtFiyat.Select(txtFiyat.Text.Length, 0);
            }

            try
            {
                 deger=(decimal.Parse(txtAdet.Text) * decimal.Parse(value));
                txtTutar.Text = string.Format(CultureInfo.CreateSpecificCulture("tr-TR"), "{0:C2}", deger/100);
            }
            catch
            {


            }


        }





        private bool TextisValid(string text)
        {
            Regex money = new Regex(@"^₺(\d{1,3}(\.\d{3})*|(\d+))(\,\d{2})?$");
            return money.IsMatch(text);
        }

           
                
         
    }
}
