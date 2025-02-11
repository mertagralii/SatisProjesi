namespace SatisProjesi.Models
{
    public class UpdateTeklifViewModel
    {
        public List<TBLDurumlar> Durumlar { get; set; }

        public List<TBLMusteri> Musteriler { get; set; }

        public SatisListesiLeftJoin Teklifler { get; set; }
    }
}
