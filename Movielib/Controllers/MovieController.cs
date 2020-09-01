using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Movielib.Entities;
using System.IO;
using System.Runtime.CompilerServices;

namespace Movielib.Controllers
{
    
    class MovieController
    {
        private string db = @"C:\Users\mikko\source\repos\Movielib\db.json";
        private string json = File.ReadAllText(@"C:\Users\mikko\source\repos\Movielib\db.json");
        public int id = 2;
       

        public List<Movie> GetMovies()
        {

            List<Movie> deserializedMovies = new List<Movie>();
            deserializedMovies = JsonConvert.DeserializeObject<List<Movie>>(json);


            return deserializedMovies;

        }

        public void AddMovie(string name, string description, int length)
        {
            List<Movie> movies = new List<Movie>();
            movies = GetMovies();
            id++;

            Movie movie = new Movie {Id = this.id, Name = name, Description = description, Length = length };
            movies.Add(movie);
            string jsonMovies = JsonConvert.SerializeObject(movies);
            File.WriteAllText(db, jsonMovies);

        }

        public void AddDummyMovies()
        {
              List<Movie> myMovies = new List<Movie>
                {
                new Movie {Id = 1, Name = "Interstellar", Description = "Sci-Fi", Length = 169 },
                new Movie {Id = 2, Name = "TestMovie", Description = "Adventure", Length = 122 }
                };
            
            string jsonMovies = JsonConvert.SerializeObject(myMovies);
            File.WriteAllText(db, jsonMovies);
        }
    }
}
