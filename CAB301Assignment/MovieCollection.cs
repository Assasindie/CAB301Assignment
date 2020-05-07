using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace CAB301Assignment
{
    class Node
    {
        public Movie Movie;
        public Node Left;
        public Node Right;
    }

    class MovieCollection
    {
        public Node Root;

        private List<Movie> TopBorrowedMovies = new List<Movie> { Capacity = 10 };

        public void Insert(Movie Movie)
        {
            Root = InsertNode(this.Root, Movie);
        }

        private Node InsertNode(Node Root, Movie Movie)
        {
            if(Root == null) //empty tree
            {
                Root = new Node { Movie = Movie};
                return Root;
            }
            else
            {
                if(Movie.Title.ToLower().CompareTo(Root.Movie.Title.ToLower()) == -1){ //If the new value is alphabetically lower than the current node.
                    Root.Left = InsertNode(Root.Left, Movie);
                } else
                {
                    Root.Right = InsertNode(Root.Right, Movie);
                }
            }
            return Root;
        }

        public void Remove(Movie Movie)
        {
            Root = RemoveNode(this.Root, Movie);
        }

        private Node RemoveNode(Node Root, Movie Movie)
        {
            if(Root == null) //empty tre
            {
                return Root;
            }

            if (Movie.Title.ToLower().CompareTo(Root.Movie.Title.ToLower()) == -1){ //If the new value is alphabetically lower than the current node.
                Root.Left = RemoveNode(Root.Left, Movie);
            }
            else if(Movie.Title.ToLower().CompareTo(Root.Movie.Title.ToLower()) == 1)
            {
                Root.Right = RemoveNode(Root.Right, Movie);
            } else // if the Title of the Movie is the same we have arrived at the node we are deleting
            {
                // for nodes with 0-1 children
                if (Root.Left == null)
                {
                    return Root.Right;
                } else if (Root.Right == null)
                {
                    return Root.Left;
                }

                //If node has 2 children find the next alphabetical ordered string and replace it 
                Root.Movie = MinMovieTitle(Root.Right);
                Root.Right = RemoveNode(Root.Right, Root.Movie);

            }
            return Root;
        }

        Movie MinMovieTitle(Node Root) //Traverses the left side of the tree from the specified node to find the smallest value after the original node
        {
            Movie Movie = Root.Movie;
            while (Root.Left != null)
            {
                Movie = Root.Left.Movie;
                Root = Root.Left;
            }
            return Movie;
        }

        public Node FindNodeWithTitle(string Title)
        {
            return FindTitle(Root, Title);
        }

        private Node FindTitle(Node Root, string Title)
        {
            if(Root == null)
            {
                return null;
            }
            if (Title.ToLower().CompareTo(Root.Movie.Title.ToLower()) == -1)
            { //If the new value is alphabetically lower than the current node go the the left branch
                return (FindTitle(Root.Left, Title));
            }
            else if (Title.ToLower().CompareTo(Root.Movie.Title.ToLower()) == 1)
            {
                return (FindTitle(Root.Right, Title));
            }
            else if(Title.ToLower().CompareTo(Root.Movie.Title.ToLower()) == 0) // Name matches
            {
                return Root;
            }
            return null;
        }

        public void TopMovies()
        {
            TraverseTopMovies(Root);
            int i = 0;
            Console.WriteLine("\nThe top borrowed movies in order are : \n");
            foreach(Movie Movie in TopBorrowedMovies.OrderBy(Movie => Movie.TimesBorrowed).Reverse())
            {
                Console.WriteLine($"{i + 1}. Title: {Movie.Title}, Times Borrowed: {Movie.TimesBorrowed}, Director: {Movie.Director}, Genre: {Movie.Genre}, Classification: {Movie.Classification}");
                   i++;
            }
            Console.WriteLine("\n");
        }

        public void TraverseTopMovies(Node Root)
        {
            //Using a private list called TopBorrowedMovies to store the information
            if (Root != null) {
                if (TopBorrowedMovies.Count != 10) //first 10 movies are added w/o having to check if they are bigger/smaller
                {
                    TopBorrowedMovies.Add(Root.Movie);
                }
                else if(Root.Movie.TimesBorrowed > TopBorrowedMovies.Min(Movie => Movie.TimesBorrowed)) //If the current has been borrowed more times than the min of the current top 10
                {
                    int x = TopBorrowedMovies.Min(Movie => Movie.TimesBorrowed);
                    Movie SmallestMovie = TopBorrowedMovies[0];
                    //loop to find min value in list and replace with Root.Movie
                    for (int i = 0; i < TopBorrowedMovies.Count; i++)
                    {
                        if (TopBorrowedMovies[i].TimesBorrowed < SmallestMovie.TimesBorrowed)
                        {
                            SmallestMovie = TopBorrowedMovies[i]; 
                        }
                    }
                    //get the index of the smallet movie and reassign it to Root.Movie
                    int index = TopBorrowedMovies.FindIndex(m => m.Title.Equals(SmallestMovie.Title));
                    TopBorrowedMovies[index] = Root.Movie;
                }
                TraverseTopMovies(Root.Left);
                TraverseTopMovies(Root.Right);
            }
        }

        public void AllMovies()
        {
            TraverseAllMovies(Root);
        }

        public void TraverseAllMovies(Node Root)
        {
            if(Root != null)
            {
                Console.Write($"Title: {Root.Movie.Title}, Copies : {Root.Movie.Copies}, Director : {Root.Movie.Director}, Starring : [");
                for (int i = 0; i < Root.Movie.Starring.Length; i++)
                {
                    if(i == Root.Movie.Starring.Length - 1)
                    {
                        Console.Write($"{Root.Movie.Starring[i]}], ");
                    }else
                    {
                        Console.Write($"{Root.Movie.Starring[i]}, ");
                    }
                }
                  Console.Write($"Length : {Root.Movie.Length}, Genre : {Root.Movie.Genre}, Classification : {Root.Movie.Classification}," +
                      $" Release Date : {Root.Movie.ReleaseDate}, Times Borrowed : {Root.Movie.TimesBorrowed} \n\n");
                TraverseAllMovies(Root.Left);
                TraverseAllMovies(Root.Right);
            }
        }

    }

}
