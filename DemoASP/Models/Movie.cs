using System.ComponentModel.DataAnnotations;

namespace DemoASP.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Realisator { get; set; }
    }
}
