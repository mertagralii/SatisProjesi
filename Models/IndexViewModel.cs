namespace SatisProjesi.Models
{
    public class IndexViewModel
    {

        public  List<TBLDurumlar> Durumlar { get; set; }

        public List<TBLMusteri> Musteriler  { get; set; }

        public List<SatisListesiLeftJoin> Teklifler { get; set; }
    }
}
