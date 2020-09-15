using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Movielib.Entities;
using System.IO;
using System.Linq;
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
            
            List<Movie> deserializedMovies = JsonConvert.DeserializeObject<List<Movie>>(json);


            return deserializedMovies;

        }

        public void AddMovie(string name, string description, int length)
        {
            List<Movie> movies = GetMovies();
            //id++;

            Movie newMovie = new Movie {movies.Count , name, description , length };
            movies.Add(newMovie);
            UpdateMoviedb(movies);

        }

        public void AddDummyMovies()
        {
            List<Movie> myMovies = GetMovies();

            Movie interstellar = new Movie { myMovies.Count, Name = "Interstellar", Description = "Sci-Fi", Length = 169 };
            myMovies.Add(interstellar);
            Movie testMovie = new Movie { myMovies.Count , Name = "TestMovie", Description = "Adventure", Length = 122 };
            myMovies.Add(testMovie);

            UpdateMoviedb(myMovies);

        }
        public void RemoveMovie(int id)
        {
            List<Movie> myMovies = GetMovies();

            myMovies.Remove(myMovies.First(movie => movie.Id == id));
            //Update id to correspond with list length to make sure movies created
            //after a removal will receive an unique id
            myMovies.ForEach(movie => movie.Id = myMovies.IndexOf(movie));
            UpdateMoviedb(myMovies);
        }

        public List<Movie> GetFilteredMovies(string filterWord)
        {
            List<Movie> moviesList = GetMovies();
            var filteredList = moviesList
                .Where(m => m.Name.ToLower().Contains(filterWord.ToLower()))
                .ToList();
            return filteredList;
        }

        private void UpdateMoviedb(List<Movie> myMovies)
        {
            string jsonMovies = JsonConvert.SerializeObject(myMovies);
            File.WriteAllText(db, jsonMovies);
        }
    }
}
