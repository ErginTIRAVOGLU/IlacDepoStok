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
    public partial class FormCari : Form
    {
        public FormCari()
        {
            InitializeComponent();
        }

        private void FormCari_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormKategoriYeni formKategoriYeni = new FormKategoriYeni();
            formKategoriYeni.ShowDialog();
        }
    }
}
