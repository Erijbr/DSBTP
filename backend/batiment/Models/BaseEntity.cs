namespace batiment.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string createdBy { get; set; }
        public DateTime createdAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
