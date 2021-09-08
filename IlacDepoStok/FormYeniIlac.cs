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
    public partial class FormYeniIlac : Form
    {
        public int? lblIdsi { get; set; }
        public FormYeniIlac()
        {
            InitializeComponent();
        }

       

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(lblIdsi==null)
            {
                IlacModel ilacModel = new IlacModel();
                int dusukStok = 0;
                ilacModel.barcode = txtBarkod.Text;
                ilacModel.adi = txtIlacAdi.Text;
                ilacModel.notu = txtIlacNotu.Text;

                string fiyat = txtFiyat.Text.Replace(".", "").Replace("₺", "").Replace(",", "").TrimStart('0');
                ilacModel.fiyat = int.Parse(fiyat);
                int.TryParse(txtDusukStok.Text, out dusukStok);
                ilacModel.dusukStok = dusukStok;
                SqliteDataAccess.SaveIlac(ilacModel);
            }
            else
            {
                IlacModel ilac = new IlacModel();
                int dusukStok = 0;
                ilac.adi = txtIlacAdi.Text;
                ilac.barcode = txtBarkod.Text;

                string fiyat = txtFiyat.Text.Replace(".", "").Replace("₺", "").Replace(",", "").TrimStart('0');
                ilac.fiyat = int.Parse(fiyat);
                int.TryParse(txtDusukStok.Text, out dusukStok);
                ilac.dusukStok = dusukStok;
                ilac.notu = txtIlacNotu.Text;
                ilac.id =int.Parse(lblIdsi.ToString());
                SqliteDataAccess.updateIlac(ilac);
            }
            
            this.Close();
        }

        private void FormYeniIlac_Load(object sender, EventArgs e)
        {

        }

        private void txtFiyat_TextChanged(object sender, EventArgs e)
        {
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
                //deger = (decimal.Parse(txtAdet.Text) * decimal.Parse(value));
                //txtTutar.Text = string.Format(CultureInfo.CreateSpecificCulture("tr-TR"), "{0:C2}", deger / 100);
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
