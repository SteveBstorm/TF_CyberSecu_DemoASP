using DemoASP.Models;

namespace DemoASP.Services
{
    public class MovieService
    {
        public  List<Movie> maListe { get; set; }
        public MovieService()
        {
            maListe = new List<Movie>();
            maListe.Add(new Movie
            {
                Id = 1,
                Title = "A New Hope",
                Description = "Un wookie et un pirate veulent se taper la princesse ...",
                Realisator = "George Lucas"
            });
            maListe.Add(new Movie
            {
                Id = 2,
                Title = "Empire strikes back",
                Description = "Les méchants gagnent pour une fois",
                Realisator = "George Lucas"
            });
        }

        public Movie GetById(int id)
        {
            return maListe.Where(f => f.Id == id).SingleOrDefault();
        }
        
        public void Create(Movie movie) 
        {
            movie.Id = (maListe.Count() > 0) ? maListe.Max(s => s.Id) + 1 : 1;
            maListe.Add(movie);
        }

        public void Edit(Movie movie)
        {
            int index = maListe.FindIndex(f => f.Id == movie.Id);
            maListe[index] = movie;
        }

        public void Delete(int id)
        {
            Movie aSupprimer = maListe.SingleOrDefault(f=> f.Id == id);
            maListe.Remove(aSupprimer);
        }
    }
}
