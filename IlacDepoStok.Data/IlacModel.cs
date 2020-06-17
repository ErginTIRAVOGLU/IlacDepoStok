namespace IlacDepoStok.Data
{
    public class IlacModel
    {
        public int id { get; set; }
        public string adi { get; set; }
        public string barcode { get; set; }
        public string notu { get; set; }
        public int dusukStok { get; set; }
        public decimal fiyat { get; set; }
    }
}