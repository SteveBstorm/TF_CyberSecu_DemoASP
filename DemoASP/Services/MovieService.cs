﻿using DemoASP.Models;

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
            movie.Id = maListe.Max(s => s.Id) + 1;
            maListe.Add(movie);
        }
    }
}
