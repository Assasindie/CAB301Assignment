using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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

    }

}
