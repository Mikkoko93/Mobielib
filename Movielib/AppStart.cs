using System;
using System.Collections.Generic;
using System.Text;
using Movielib.Controllers;
using Movielib.Entities;

namespace Movielib
{
    class AppStart { 

    private MovieController controller;
    public AppStart(MovieController c)
    {
        controller = c;
    }

    public void Start()
    {
        Boolean active = true;
        while (active)
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("Hello and welcome to Buutti Movie Database!");
            Console.WriteLine("Please insert your command (type \"help\" for the list of available commands)");
            string input = Console.ReadLine();

            switch (input)
            {
                case "help":
                    PrintHelp();
                    break;
                case "quit":
                    Console.WriteLine("Quitting application");
                    active = false;
                    break;
                case "search":
                    Search();
                    break;
                case "add":
                    AddDialog();
                    break;
                case "remove":
                    RemoveDialog();
                    break;

                case "print":
                    printDetails();
                    break;
                case "dummies":
                    controller.AddDummyMovies();
                    break;

                default:
                    Console.WriteLine("Unknown command, please try again\n");
                    break;
            }
        }

        void PrintHelp()
        {
            Console.WriteLine("\nHere’s a list of commands you can use!\n");
            Console.WriteLine("help\tOpen this dialog.");
            Console.WriteLine("quit\tQuit the program.\n");
            Console.WriteLine("search\tList movies by search term.");
            Console.WriteLine("add\tAdd a new movie to the database.");
            Console.WriteLine("remove\tRemove a movie from the database.");

            //extras
            Console.WriteLine("print\tPrint a list of the movies in the database");
            Console.WriteLine("dummies\tAdd a selection of 2020s best movies to the database.");
        }

        void Search()
        {
            Console.WriteLine("Enter your search term:");
            string input = Console.ReadLine();
            List<Movie> filteredList = controller.GetFilteredMovies(input);
            switch (filteredList.Count)
            {
                case (0):
                    Console.WriteLine($"No movies found with search term '{input}' :(");
                    break;
                case (1):
                    Console.WriteLine($"Found 1 movie with search term '{input}':");
                    break;
                default:
                    Console.WriteLine($"Found {filteredList.Count} movies with search term '{input}':");
                    break;
            }

            foreach (Movie m in filteredList)
            {
                Console.WriteLine(m.Id + " " + m.Name + ", length: " + m.Length + "m");
            }
            Console.WriteLine();
        }

        void AddDialog()
        {
            try
            {
                Console.WriteLine("\nAdding a movie");
                Console.WriteLine("Please enter the details for the movie!");

                Console.WriteLine("Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Description:");
                string desc = Console.ReadLine();
                Console.WriteLine("Length:");
                int length = Int32.Parse(Console.ReadLine());

                controller.AddMovie(name, desc, length);
                Console.WriteLine($"Movie {name} added!\n");
            }
            catch
            {
                Console.WriteLine("Invalid input: Give length in minutes.");
                Console.WriteLine("Movie not added. Please try again. \n");
            }
        }

        void printDetails()
        {
            List<Movie> allMovies = controller.GetMovies();
            if (allMovies.Count == 0)
            {
                Console.WriteLine("No movies in the database. Please add a movie.");
            }

            foreach (Movie m in allMovies)
            {
                Console.WriteLine(m.Id + " " + m.Name + ", length: " + m.Length + "m");
            }

            Console.WriteLine("");
        }

        void RemoveDialog()
        {
            try
            {
                Console.WriteLine("Removing a movie.");
                Console.WriteLine("Please enter the ID of the movie you want to remove:");
                int id = Int32.Parse(Console.ReadLine());

                Console.WriteLine($"Removing movie {controller.GetMovies()[id].Name}. Are you sure (y/n)?");
                string conf = Console.ReadLine();
                switch (conf)
                {
                    case "y":
                        controller.RemoveMovie(id);
                        Console.WriteLine("Movie removed from the database.\n");
                        break;
                    case "n":
                        Console.WriteLine("Cancelling removal.\n");
                        break;
                    default:
                        Console.WriteLine("Unknown command. Please use \"y\" or \"n\"");
                        break;
                }
            }
            catch (Exception e)
            {
                switch (e.GetType().Name)
                {
                    case "FormatException":
                        Console.WriteLine("Wrong input format. Please provide an id number. Type \"print\" for list of movies and ids\n");
                        break;
                    case "ArgumentOutOfRangeException":
                        Console.WriteLine("Invalid id number. Type \"print\" for list of movies and ids\n");
                        break;
                }
            }
        }
    }
}
}
