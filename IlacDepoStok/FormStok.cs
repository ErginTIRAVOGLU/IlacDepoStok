﻿using IlacDepoStok.Data;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IlacDepoStok
{
    public partial class FormStok : Form
    {
        public FormStok()
        {
            InitializeComponent();
        }

        private void btnStokListele_Click(object sender, EventArgs e)
        {
            List<StokModel> sModel = new List<StokModel>();
            //dGVStok.DataSource = sModel;
            dGVStok.DataSource = null;
            dGVStok.Columns.Clear();
            //List<IlacModel> ilaclar = new List<IlacModel>();
            //ilaclar = SqliteDataAccess.LoadIlaclar();

            DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "id";
            textBoxColumn.HeaderText = "No";
            textBoxColumn.Visible = false;
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "adi";
            textBoxColumn.HeaderText = "Ilac";
            textBoxColumn.Width=250;
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "barcode";
            textBoxColumn.HeaderText = "Barcode";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "notu";
            textBoxColumn.HeaderText = "Not";
            dGVStok.Columns.Add(textBoxColumn);


            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "dusukStok";
            textBoxColumn.HeaderText = "Düşük Stok";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "gireni";
            textBoxColumn.HeaderText = "Toplam Giren";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "cikani";
            textBoxColumn.HeaderText = "Toplam Çıkan";
            dGVStok.Columns.Add(textBoxColumn);

            textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.DataPropertyName = "Stok";
            textBoxColumn.HeaderText = "Kalan Stok";
            dGVStok.Columns.Add(textBoxColumn);

            sModel = SqliteDataAccess.stokDurumu(((DepoModel)(cmbDepo.SelectedItem)).id);


            dGVStok.DataSource = sModel;
        }

        private void FormStok_Load(object sender, EventArgs e)
        {
            cmbDepo.DisplayMember = "adi";
            cmbDepo.ValueMember = "id";
            List<DepoModel> depolar = new List<DepoModel>();
            depolar.Add(new DepoModel() { adi = "Tüm Depolar", id = 0 });
            depolar.AddRange(SqliteDataAccess.LoadDepolar());
            cmbDepo.DataSource = depolar;
            cmbDepo.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < dGVStok.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dGVStok.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dGVStok.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dGVStok.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dGVStok.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save the application  
            workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Quit();
        }

        
         
    }
}
