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
    }
}
