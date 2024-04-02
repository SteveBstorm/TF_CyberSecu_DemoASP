﻿using DemoASP.Models;
using Microsoft.Data.SqlClient;

namespace DemoASP.Services
{
    public class MovieService
    {
        /*
         Modifier le service pour qu'il fonctionne avec la DB plutot qu'avec une simple liste
         */
        private string connectionString = @"Data Source=DESKTOP-56GOFPS\DEVPERSO;Initial Catalog=TFCyberSecu_MovieDB;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public List<Movie> maListe { get; set; }
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Movie";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
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
            Movie m = new Movie();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Movie WHERE Id = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            m.Id = (int)reader["Id"];
                            m.Title = (string)reader["Title"];
                            m.Description = (string)reader["Description"];
                            m.Realisator = (string)reader["Realisator"];
                        }
                    }
                    connection.Close();
                }
            }
            return m;
        }

        public bool Create(MovieCreateForm movie)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd =  new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO Movie (Title, Description, Realisator) " +
                        "VALUES (@title, @desc, @real)";

                    cmd.Parameters.AddWithValue("title", movie.Title);
                    cmd.Parameters.AddWithValue("desc", movie.Description);
                    cmd.Parameters.AddWithValue("real", movie.Realisator);

                    try
                    {
                        connection.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (SqlException ex) 
                    {
                        //Gérer l'exception
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    connection.Close();
                }
            }

            //movie.Id = (maListe.Count() > 0) ? maListe.Max(s => s.Id) + 1 : 1;
            //maListe.Add(movie);
        }

        public void Edit(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "UPDATE Movie SET Title = @title, Description = @desc, Realisator = @real " +
                        "WHERE Id = @id";

                    cmd.Parameters.AddWithValue("id", movie.Id);
                    cmd.Parameters.AddWithValue("title", movie.Title);
                    cmd.Parameters.AddWithValue("desc", movie.Description);
                    cmd.Parameters.AddWithValue("real", movie.Realisator);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            //int index = maListe.FindIndex(f => f.Id == movie.Id);
            //maListe[index] = movie;
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM Movie WHERE Id = @id";

                    cmd.Parameters.AddWithValue("id", id);
                    

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            //Movie aSupprimer = maListe.SingleOrDefault(f => f.Id == id);
            //maListe.Remove(aSupprimer);
        }
    }
}
