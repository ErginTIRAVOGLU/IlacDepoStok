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
        }
        List<IlacModel> ilaclar = new List<IlacModel>();
        private void Form1_Load(object sender, EventArgs e)
        {
            loadIlacList();
        }
        private void loadIlacList()
        {
            ilaclar = SqliteDataAccess.LoadIlaclar();
        }
    }
}
