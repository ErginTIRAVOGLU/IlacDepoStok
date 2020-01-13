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
            IlacModel ilacModel = new IlacModel();
            ilacModel.barcode = txtBarkod.Text;
            ilacModel.adi = txtIlacAdi.Text;
            ilacModel.notu = txtIlacNotu.Text;
            SqliteDataAccess.SaveIlac(ilacModel);
            this.Close();
        }
    }
}
