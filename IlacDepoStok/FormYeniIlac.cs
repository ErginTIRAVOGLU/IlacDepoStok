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
            if(String.IsNullOrEmpty(lblIdsi.Text))
            {
                IlacModel ilacModel = new IlacModel();
                int dusukStok = 0;
                ilacModel.barcode = txtBarkod.Text;
                ilacModel.adi = txtIlacAdi.Text;
                ilacModel.notu = txtIlacNotu.Text;
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
                int.TryParse(txtDusukStok.Text, out dusukStok);
                ilac.dusukStok = dusukStok;
                ilac.notu = txtIlacNotu.Text;
                ilac.id = int.Parse(lblIdsi.Text);
                SqliteDataAccess.updateIlac(ilac);
            }
            
            this.Close();
        }

        private void FormYeniIlac_Load(object sender, EventArgs e)
        {

        }
    }
}
