using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301Assignment
{
    class MemberMenuFunctions
    {
        public static void DisplayAllMovies(Member Member)
        {
            if(Program.Movies.Root == null)
            {
                Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Error: No movies found.");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!\n");
            }else
            {
                Console.WriteLine("\n=============");
                Console.WriteLine("The following movies have been registered into the Database");
                Program.Movies.AllMovies();
                Console.WriteLine("=============\n");
            }
            DisplayText.MemberMenu(Member);            
        }

        public static void DisplayTopMovies(Member Member)
        {
            Program.Movies.TopMovies();
            DisplayText.MemberMenu(Member);
        }

        public static void BorrowMovie(Member Member)
        {
            Console.WriteLine("Please enter the title of the movie you wish to borrow");
            Movie SelectedMovie = Program.Movies.FindNodeWithTitle(Console.ReadLine()).Movie;
            if (SelectedMovie == null)
            {
                Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Error: Movie name not found.");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!\n");
            }
            else
            {
                if (SelectedMovie.Copies == 0)
                {
                    Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("Error: No copies of the movie are left.");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!\n");
                }
                else
                {
                    Member.BorrowedMovies.Add(SelectedMovie);
                    SelectedMovie.Copies--;
                    SelectedMovie.TimesBorrowed++;

                    Console.WriteLine("\n=============");
                    Console.WriteLine("Movie Borrowed.");
                    Console.WriteLine("=============\n");
                }
            }
            DisplayText.MemberMenu(Member);
        }

        public static void ReturnMovie(Member Member)
        {
            Console.WriteLine("Please enter the title of the movie you wish to return");
            Movie SelectedMovie = Program.Movies.FindNodeWithTitle(Console.ReadLine()).Movie;
            if (SelectedMovie == null)
            {
                Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Error: Movie name not found.");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!\n");
            }else if(!Member.BorrowedMovies.Contains(SelectedMovie)) 
            {
                Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Error: You have not borrowed this movie.");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!\n");
            }
            else
            {
                SelectedMovie.Copies++;
                Member.BorrowedMovies.Remove(SelectedMovie);

                Console.WriteLine("\n=============");
                Console.WriteLine("Movie Returned.");
                Console.WriteLine("=============\n");
            }

            DisplayText.MemberMenu(Member);
        }

        public static void DisplayCurrentMovies(Member Member)
        {
            if (Member.BorrowedMovies.Count == 0)
            {
                Console.WriteLine("\n=============");
                Console.WriteLine("You have no borrowed movies.");
                Console.WriteLine("=============\n");
            }
            else
            {
                Console.WriteLine("\n=============");
                Console.WriteLine("Your current movies are : ");
                foreach (Movie Movie in Member.BorrowedMovies)
                {
                    Console.WriteLine(Movie.Title);
                }
                Console.WriteLine("=============\n");
            }
            DisplayText.MemberMenu(Member);
        }
    }
}
