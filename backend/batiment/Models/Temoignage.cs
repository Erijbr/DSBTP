namespace batiment.Models
{
    public class Temoignage: BaseEntity
    {
        public int Note { get; set; }
        public string Appreciation { get; set; }
        public string Amelioration { get; set; }
        public string Email { get; set; }
        public int IdService { get; set; }
        public bool affiche { get; set; }
    }
}
