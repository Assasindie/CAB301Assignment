using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301Assignment
{
    class MemberMenuFunctions // all the functions in this class display text and then call the appropriate function to perform the action
    {
        public static void DisplayAllMovies(Member Member) //displays all the movies
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

        public static void DisplayTopMovies(Member Member) //displays top 10 movies
        {
            Program.Movies.TopMovies();
            DisplayText.MemberMenu(Member);
        }

        public static void BorrowMovie(Member Member) //borrows a movie
        {
            if (Member.BorrowedMovies.Count != 10)
            {
                Console.WriteLine("Please enter the title of the movie you wish to borrow");
                Node SelectedMovieNode = Program.Movies.FindNodeWithTitle(Console.ReadLine());
                if (SelectedMovieNode == null)
                {
                    Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("Error: Movie name not found.");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!\n");
                }
                else
                {
                    Movie SelectedMovie = SelectedMovieNode.Movie;
                    if (SelectedMovie.Copies == 0)
                    {
                        Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!");
                        Console.WriteLine("Error: No copies of the movie are left.");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!\n");
                    }
                    else
                    {
                        if (Member.BorrowedMovies.Contains(SelectedMovie))
                        {
                            Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!");
                            Console.WriteLine("Error: You have already borrowed this movie.");
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
                }
            } else
            {
                Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Error: You have already borrowed 10 movies");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!\n");
            }
            DisplayText.MemberMenu(Member);
        }

        public static void ReturnMovie(Member Member) //return movie
        {
            Console.WriteLine("Please enter the title of the movie you wish to return");
            Node SelectedMovieNode = Program.Movies.FindNodeWithTitle(Console.ReadLine());
            if (SelectedMovieNode == null)
            {
                Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Error: Movie name not found.");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!\n");
            }else if(!Member.BorrowedMovies.Contains(SelectedMovieNode.Movie)) 
            {
                Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Error: You have not borrowed this movie.");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!\n");
            }
            else
            {
                SelectedMovieNode.Movie.Copies++;
                Member.BorrowedMovies.Remove(SelectedMovieNode.Movie);

                Console.WriteLine("\n=============");
                Console.WriteLine("Movie Returned.");
                Console.WriteLine("=============\n");
            }

            DisplayText.MemberMenu(Member);
        }

        public static void DisplayCurrentMovies(Member Member) //display currently borrowed movies
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
