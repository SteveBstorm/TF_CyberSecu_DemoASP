using System.ComponentModel.DataAnnotations;

namespace DemoASP.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Un film ça a un titre abruti")]
        //[EmailAddress]
        public string Title { get; set; }

        //[Compare(nameof(Title))]
        //public string ConfirmTitle { get; set; }
        [Required]
        [MinLength(40, ErrorMessage = "La description doit faire un minimum de 40 caractères")]
        public string Description { get; set; }
        [Required]
        public string Realisator { get; set; }
    }
}
