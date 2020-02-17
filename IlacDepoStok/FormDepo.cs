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
    public partial class FormDepo : Form
    {
        public FormDepo()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtDepoAdi.Text))
            { 
                DepoModel depo = new DepoModel();
                depo.adi = txtDepoAdi.Text;
                SqliteDataAccess.SaveDepo(depo);
                txtDepoAdi.Text = "";
                loadDepo();
                btnEkle.Enabled = false;
            }
        }

        private void FormDepo_Load(object sender, EventArgs e)
        {
            loadDepo();
        }
        private void loadDepo()
        {
            lstBoxDepolar.DisplayMember = "adi";
            lstBoxDepolar.ValueMember = "id";
            lstBoxDepolar.DataSource = SqliteDataAccess.LoadDepolar();
            lstBoxDepolar.ClearSelected();
            btnSil.Enabled = false;
        }

        private void lstBoxDepolar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstBoxDepolar.SelectedItem!=null)
            { 
                btnSil.Enabled = true;
                txtDepoAdi.Text = ((DepoModel)(lstBoxDepolar.SelectedItem)).adi;
                txtDepoAdi.Enabled = false;
                btnVazgec.Enabled = true;
                btnYeniEkle.Enabled = false;
                btnEkle.Enabled = false;
                btnDegistir.Enabled = true;
            }
            else
            {
                txtDepoAdi.Text = "";
                txtDepoAdi.Enabled = false;
                btnVazgec.Enabled = false;
                btnYeniEkle.Enabled = true;
                btnDegistir.Enabled = false;
            }
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            txtDepoAdi.Enabled = true;
            btnKaydet.Enabled = true;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDepoAdi.Text))
            {
                DepoModel depo = new DepoModel();
                depo.adi = txtDepoAdi.Text;
                depo.id= ((DepoModel)(lstBoxDepolar.SelectedItem)).id;
                SqliteDataAccess.updateDepo(depo);
                loadDepo();
            }
        }

        private void btnYeniEkle_Click(object sender, EventArgs e)
        {
            btnDegistir.Enabled = false;
            btnKaydet.Enabled = false;
            btnSil.Enabled = false;
            btnEkle.Enabled = true;
            btnVazgec.Enabled = true;
            btnYeniEkle.Enabled = false;
            txtDepoAdi.Enabled = true;
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            btnDegistir.Enabled = false;
            btnKaydet.Enabled = false;
            btnSil.Enabled = false;
            
            btnYeniEkle.Enabled = true;

            btnEkle.Enabled = false;
            btnVazgec.Enabled = false;

            txtDepoAdi.Text = "";
            txtDepoAdi.Enabled = false;

            lstBoxDepolar.ClearSelected();


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Seçili Depo'yu Silmek İstediğinizden Emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dr.")
            int depoId=((DepoModel)(lstBoxDepolar.SelectedItem)).id;
            SqliteDataAccess.DeleteDepo(depoId);
            
            loadDepo();
            btnKaydet.Enabled = false;
        }
    }
}
