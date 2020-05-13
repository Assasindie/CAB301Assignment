using System;

namespace CAB301Assignment
{
    class Program
    {
        public static MemberCollection Members = new MemberCollection();
        public static MovieCollection Movies = new MovieCollection();

        static void Main(string[] args)
        {
           //initialise lists with some movies
            Movie Movie1 = new Movie { Classification = Classification.Genral, Genre = Genre.Adventure, Copies = 0, Director = "Jeff", Starring = new string[] { "People", "Brad", "Someone" },
                Length = 150, ReleaseDate = "11/11/11", TimesBorrowed = 0, Title = "Movie 1" };
            Movie Movie2 = new Movie { Classification = Classification.Mature, Genre = Genre.Action, Copies = 10, Director = "Brad", Starring = new string[] { "Famous Person", "Someone" },
                Length = 170, ReleaseDate = "11/11/11", TimesBorrowed = 5, Title = "Movie 2" };
            Movie Movie3 = new Movie { Classification = Classification.Mature_Accompanied, Genre = Genre.Animated, Copies = 2, Director = "Alex", Starring = new string[] { "People", "Jeff" },
                Length = 200, ReleaseDate = "11/11/11", TimesBorrowed = 10, Title = "Movie 3" };
            Movie Movie4 = new Movie { Classification = Classification.Parental_Guidance, Genre = Genre.Comedy, Copies = 8, Director = "Fred", Starring = new string[] { "Famous Person", "Actor Person" },
                Length = 100, ReleaseDate = "11/11/11", TimesBorrowed = 12, Title = "Movie 4" };
            Movie Movie5 = new Movie { Classification = Classification.Genral, Genre = Genre.Drama, Copies = 10, Director = "Tony", Starring = new string[] { "Lachlan", "Mr Bones" },
                Length = 150, ReleaseDate = "11/11/11", TimesBorrowed = 4, Title = "Movie 5" };
            Movie Movie6 = new Movie { Classification = Classification.Mature_Accompanied, Genre = Genre.Family, Copies = 5, Director = "Jeff", Starring = new string[] { "Actor Person", "Someone" },
                Length = 53, ReleaseDate = "11/11/11", TimesBorrowed = 8, Title = "Movie 6" };
            Movie Movie7 = new Movie { Classification = Classification.Genral, Genre = Genre.Other, Copies = 4, Director = "Steve", Starring = new string[] { "Brad", "Overpaid Person" },
                Length = 57, ReleaseDate = "11/11/11", TimesBorrowed = 9, Title = "Movie 7" };
            Movie Movie8 = new Movie { Classification = Classification.Parental_Guidance, Genre = Genre.SciFi, Copies = 20, Director = "Lewis", Starring = new string[] { "Actor Person", "People" },
                Length = 80, ReleaseDate = "11/11/11", TimesBorrowed = 14, Title = "Movie 8" };
            Movie Movie9 = new Movie { Classification = Classification.Genral, Genre = Genre.Thriller, Copies = 15, Director = "Richard", Starring = new string[] { "Brad", "Mr Bones" },
                Length = 90, ReleaseDate = "11/11/11", TimesBorrowed = 20, Title = "Movie 9" };
            Movie Movie10 = new Movie { Classification = Classification.Genral, Genre = Genre.Adventure, Copies = 6, Director = "Lachlan", Starring = new string[] { "Jeff", "Mr Bones" },
                Length = 180, ReleaseDate = "11/11/11", TimesBorrowed = 50, Title = "Movie 10" };
            Movie Movie11 = new Movie { Classification = Classification.Mature, Genre = Genre.Drama, Copies = 7, Director = "Marcus", Starring = new string[] { "Josh", "Colin" },
                Length = 200, ReleaseDate = "11/11/11", TimesBorrowed = 10, Title = "Movie 11" };
            Movie Movie12 = new Movie { Classification = Classification.Genral, Genre = Genre.Other, Copies = 9, Director = "Josh", Starring = new string[] { "Josh" },
                Length = 240, ReleaseDate = "11/11/11", TimesBorrowed = 8, Title = "Movie 12" };
            Movies.Insert(Movie1);
            Movies.Insert(Movie2);
            Movies.Insert(Movie3);
            Movies.Insert(Movie4);
            Movies.Insert(Movie5);
            Movies.Insert(Movie6);
            Movies.Insert(Movie7);
            Movies.Insert(Movie8);
            Movies.Insert(Movie9);
            Movies.Insert(Movie10);
            Movies.Insert(Movie11);
            Movies.Insert(Movie12);
            
            //initialise list with some people
            Member Alex = new Member { Address = "2 George St, Brisbane City QLD 4000", FirstName = "Alex", LastName = "Butler",
                Password = 2121, PhoneNumber = "0487123456", UserName = "ButlerAlex" };
            Members.InsertMember(Alex);

            Member Tony = new Member { Address = "St Lucia QLD 4072", FirstName = "Tony", LastName = "Li",
                Password = 1234, PhoneNumber = "0487987654", UserName = "LiTony" };
            Members.InsertMember(Tony);

            //Start Program
            DisplayText.MainMenu();
        }
    }
}
