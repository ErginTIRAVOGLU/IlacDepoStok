namespace IlacDepoStok.Data
{
    public class StokHareketModel
    {
        public int id { get; set; }
        public string ilac_adi { get; set; }
        public string barcode { get; set; }
        public string cari_ad_soyad { get; set; }
        public string depo_adi { get; set; }
        public string yon { get; set; }
        public string tarih { get; set; }
        public decimal fiyat { get; set; }
        public int adet { get; set; }
        public decimal tutar { get; set; }
    }
}