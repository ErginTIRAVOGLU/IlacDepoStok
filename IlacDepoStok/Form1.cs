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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dGVHareket.AutoGenerateColumns = false;
        }
        List<IlacModel> ilaclar = new List<IlacModel>();
        private void Form1_Load(object sender, EventArgs e)
        {
         
            
            loadIlacList();
        }
        

     
        private void txtBarkod_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if(!String.IsNullOrEmpty(txtBarkod.Text))
                { 
                    IlacModel ilac = barkodAra(txtBarkod.Text);
                    if(ilac != null)
                    {
                        txtIlacAdi.Text = ilac.adi;
                        lblIacNot.Text = ilac.notu;
                        List<HareketModel> ilacHareket = new List<HareketModel>();
                        ilacHareket = SqliteDataAccess.findHareketbyIlacId(ilac.id);
                        dGVHareket.DataSource = ilacHareket;
                    }
                    else
                    {
                        txtIlacAdi.Text = "";
                        lblIacNot.Text = "İlaç Kaydı Bulunamadı.";

                        List<HareketModel> ilacHareket = new List<HareketModel>();
                        dGVHareket.DataSource = ilacHareket;

                        DialogResult dialogResult = new DialogResult();
                        dialogResult = MessageBox.Show("Bu Barkod Numarasına Kayıtlı Bir İlaç Bulunamadı. Yeni İlaç Kayıt Etmek İster misiniz?", "Yeni İlaç Kayıt", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    
                        if(dialogResult==DialogResult.Yes)
                        {
                            FormYeniIlac formYeniIlac = new FormYeniIlac();
                            TextBox newtxtBarkod = (TextBox)formYeniIlac.Controls["txtBarkod"];
                            TextBox newtxtIlacAdi = (TextBox)formYeniIlac.Controls["txtIlacAdi"];
                            newtxtBarkod.Text = txtBarkod.Text;
                            newtxtIlacAdi.Select();
                            formYeniIlac.ShowDialog();                            
                        }
                    
                    }
                }
            }
        }



        private IlacModel barkodAra(string barkod)
        {
            IlacModel ilac = SqliteDataAccess.findIlacbyBarkod(barkod);
            return ilac;
        }
        private void loadIlacList()
        {
            ilaclar = SqliteDataAccess.LoadIlaclar();

            DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "id";
            textBoxColumn.HeaderText = "No";
            textBoxColumn.Visible = false;
            dGVHareket.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "adet";
            textBoxColumn.HeaderText = "Adet";
            dGVHareket.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "yon";
            textBoxColumn.HeaderText = "Yön";
            dGVHareket.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "tarih";
            textBoxColumn.HeaderText = "Tarih";
            dGVHareket.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "fiyat";
            textBoxColumn.HeaderText = "Fiyat";
            dGVHareket.Columns.Add(textBoxColumn);
        }

        private void txtBarkod_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

        }
    }
}
