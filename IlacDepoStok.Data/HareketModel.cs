using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlacDepoStok.Data
{
	public class HareketModel
	{

		public int id { get; set; }

		public string ilac_adi { get; set; }
		public string yon { get; set; }
		public int adet { get; set; }
		public string depo_adi { get; set; }
		public decimal fiyat { get; set; }
		public decimal tutar { get; set; }
		public string tarih { get; set; }
		

		public int cari_id { get; set; }
		public int ilac_id { get; set; }		
		public string cariadsoyad { get; set; }		
		public int depo_id { get; set; }
		

	}
}
