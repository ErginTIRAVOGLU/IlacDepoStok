using IlacDepoStok.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IlacDepoStok
{
    public partial class FormKategoriYeni : Form
    {
        public FormKategoriYeni()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            KategoriModel kategoriModel = new KategoriModel();
            kategoriModel.Kategori_Adi = textBox1.Text;
        }
    }
}
