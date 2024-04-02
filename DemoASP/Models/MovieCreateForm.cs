using System.ComponentModel.DataAnnotations;

namespace DemoASP.Models
{
    public class MovieCreateForm
    {
        [Required(ErrorMessage = "Un film ça a un titre abruti")]
        public string Title { get; set; }

        [Required]
        [MinLength(40, ErrorMessage = "La description doit faire un minimum de 40 caractères")]
        public string Description { get; set; }
        [Required]
        public string Realisator { get; set; }
    }
}
