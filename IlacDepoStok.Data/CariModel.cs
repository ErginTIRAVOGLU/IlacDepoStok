﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IlacDepoStok.Data
{
    public class CariModel
    {
        public int cari_id { get; set; }
        public string cari_ad_soyad { get; set; }
        public int cari_kategori_id { get; set; }

        public string cari_telefon { get; set; }
        public string cari_adres { get; set; }
        public string cari_not { get; set; }
    }
}
