namespace SatisProjesi.Models
{
    public class SatisListesiLeftJoin
    {
        // Teklifler Tablosundan Kullanacaklarım
        public int Id { get; set; }

        public int MusteriId { get; set; }

        public int DurumId { get; set; }

        public string TeklifBaslik { get; set; }

        public int Fiyat { get; set; }


        // Müşteriler Tablosundan Kullanacaklarım
        public string MusteriAdi { get; set; }

        public string MusteriSoyadi { get; set; }


        // Durumlar Tablosundan Kullanacaklarım
        public string DurumAdi { get; set; }
    }
}
