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

            //MovieController controller = new MovieController();
            AppStart appStart = new AppStart(mc);
            appStart.Start();

            /*//mc.AddDummyMovies();
            // mc.AddMovie("The Hobbit", "Adventure", 147);
            List<Movie> movies = mc.GetMovies();
            while (true)
            {
                string c = Console.ReadLine();
                switch (c)
                {
                    case "1":
                        Console.WriteLine("name of the Movie");
                        string name = Console.ReadLine();
                        Console.WriteLine("description:");
                        string description = Console.ReadLine();
                        Console.WriteLine("Length of the movie");
                        Int32.TryParse(Console.ReadLine(), out int length);
                        mc.AddMovie(name, description, length);
                        Console.WriteLine("Movie added");
                        break;
                    case "2":
                        foreach (Movie movie in movies)
                        {
                            Console.WriteLine(movie.Name);
                        }
                        break;
                }
                    
            }*/



        }
    }
}
