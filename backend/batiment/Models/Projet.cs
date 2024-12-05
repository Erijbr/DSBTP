namespace batiment.Models
{
    public class Projet: BaseEntity
    {
        public string Nom { get; set; }
        public string Description { get; set; }
       
        public  string[] Images { get; set; }
    }
}
