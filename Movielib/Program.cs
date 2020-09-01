using System;
using System.Collections.Generic;
using Movielib.Controllers;
using Movielib.Entities;

namespace Movielib
{
    class Program
    {
        static void Main(string[] args)
        {

            MovieController mc = new MovieController();
            //mc.AddDummyMovies();
            mc.AddMovie("The Hobbit", "Adventure", 147);
            List<Movie> movies = mc.GetMovies();
            foreach (Movie movie in movies)
            {
                Console.WriteLine(movie.Name);
            }
        }
    }
}
