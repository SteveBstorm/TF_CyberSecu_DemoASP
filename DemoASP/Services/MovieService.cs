using DemoASP.Models;
using Microsoft.Data.SqlClient;

namespace DemoASP.Services
{
    public class MovieService
    {
        /*
         Modifier le service pour qu'il fonctionne avec la DB plutot qu'avec une simple liste
         */
        private string connectionString = @"Data Source=DESKTOP-56GOFPS\DEVPERSO;Initial Catalog=TFCyberSecu_MovieDB;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public  List<Movie> maListe { get; set; }
        public MovieService()
        {
            //maListe = new List<Movie>();
            //maListe.Add(new Movie
            //{
            //    Id = 1,
            //    Title = "A New Hope",
            //    Description = "Un wookie et un pirate veulent se taper la princesse ...",
            //    Realisator = "George Lucas"
            //});
            //maListe.Add(new Movie
            //{
            //    Id = 2,
            //    Title = "Empire strikes back",
            //    Description = "Les méchants gagnent pour une fois",
            //    Realisator = "George Lucas"
            //});
        }

        public List<Movie> GetAll()
        {
            List<Movie> list = new List<Movie>();
            using(SqlConnection connection = new SqlConnection(connectionString)) 
            { 
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Movie";
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader()) 
                    {
                        while (reader.Read())
                        {
                            list.Add(new Movie
                            {
                                Id = (int)reader["Id"],
                                Title = (string)reader["Title"],
                                Description = (string)reader["Description"],
                                Realisator = (string)reader["Realisator"]
                            });
                        }
                    }
                    connection.Close();
                }
            }
            return list;
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
