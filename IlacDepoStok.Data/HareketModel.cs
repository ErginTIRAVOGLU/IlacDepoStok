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
		
		public string yon { get; set; }
		public int adet { get; set; }
		 
		public int ilac_id { get; set; }
		public string tarih { get; set; }
		public string adi { get; set; }
		public virtual IlacModel ilac {get; set;}
    }
}
