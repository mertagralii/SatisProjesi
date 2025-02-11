namespace SatisProjesi.Models
{
    public class TBLDurumlar
    {

        public int Id { get; set; }

        public string DurumAdi { get; set; }

        public int DurumSirasi { get; set; }

        public List<TBLTeklif> Teklifler { get; set; }
    }
}
