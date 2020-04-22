using System;

namespace CAB301Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieCollection test = new MovieCollection();
            Movie Movie = new Movie { Title = "50" };
            Movie Movie2 = new Movie { Title = "20" };
            Movie Movie3 = new Movie { Title = "30" };
            test.Insert(Movie);
            test.Insert(Movie3);
            test.Insert(Movie2);
            test.Insert(new Movie { Title = "40" });
            test.Insert(new Movie { Title = "70" });
            test.Insert(new Movie { Title = "60" });
            test.Insert(new Movie { Title = "80", Classification = Rating.Genral });

            Movie = test.FindNodeWithTitle("20").Movie;
            Console.WriteLine(Movie.Title);
        }
    }
}
