using batiment.Models;
namespace batiment.models
{
    public class user : BaseEntity
    {
        public string Nom { get; set; }
       
        public string Email { get; set; }
        public string Motdepasse { get; set; }
    
        public int Numtelephone { get; set; }
        public string Position { get; set; }
        public string Poste { get; set; }



    }

}



//using batiment.Models;
//using System.ComponentModel.DataAnnotations;

//namespace Batiment.Models
//{
//    public class AppUser : BaseEntity
//    {
//        [Required]
//        [StringLength(100)]
//        public string Nom { get; set; }

//        [Required]
//        [StringLength(100)]
//        public string Prenom { get; set; }

//        [Required]
//        [EmailAddress]
//        [StringLength(255)]
//        public string Email { get; set; }

//        [Required]
//        [DataType(DataType.Password)]
//        public string MotDePasse { get; set; } // Assurez-vous de le hacher avant de le stocker

//        [StringLength(100)]
//        public string Ville { get; set; }

//        [StringLength(100)]
//        public string Region { get; set; }

//        //[Range(10000, 99999)] // Ajustez selon le format de votre code postal
//        public int CodePostal { get; set; }

//        [StringLength(100)]
//        public string Pays { get; set; }

//        [StringLength(255)]
//        public string Adresse { get; set; }

//        [Phone]
//        public string NumTelephone { get; set; } // Changez le type en string pour gérer les numéros formatés

//        [StringLength(100)]
//        public string Position { get; set; } // Correction de la majuscule
//    }
//}
