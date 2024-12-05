namespace batiment.Models
{
    public class RendezVous: BaseEntity
    {
        public DateTime Date { get; set; }
        public string Heure { get; set; }
        public string Msg { get; set; }
        public string Email { get; set; }
        public bool accept { get; set; }
    }
}
