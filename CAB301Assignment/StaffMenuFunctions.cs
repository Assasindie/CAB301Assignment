using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAB301Assignment
{
    class StaffMenuFunctions //these functions are primarily focused on the text and input and call the appropriate function to add/remove/lookup information
    {
        public static void AddMovie()
        {
            Movie NewMovie = new Movie();

            //Title
            Console.WriteLine("Please enter movie title");
            NewMovie.Title = Console.ReadLine();

            //Starring
            Console.WriteLine("Please enter who the movie is starring seperated by commas");
            NewMovie.Starring = Console.ReadLine().Split(",");

            //Director
            Console.WriteLine("Please enter the director's name");
            NewMovie.Director = Console.ReadLine();

            //Movie Length
            bool CorrectInput = false;
            string Input = "";
            static void MovieLengthText() => Console.WriteLine("Please enter the length of the movie in minutes"); // function to repeat the text when handling bad input for length
            MovieLengthText();
            //Validate input
            while (!CorrectInput)
            {
                Input = Console.ReadLine();
                CorrectInput = DisplayText.HandleIntInput(Input, MovieLengthText, 1000);
            }
            NewMovie.Length = int.Parse(Input);
            CorrectInput = false;

            //Genre
            Console.WriteLine("Please enter the number that corresponds to the Genre of Movie");
            int i = 0;
            foreach(Genre str in Enum.GetValues(typeof(Genre))) //Loop through the enum and have the staff choose the number (easier than typing and more consistent)
            {
                Console.WriteLine($"{i}. {str}");
                i++;
            }

            static void GenreMovieText() => Console.WriteLine("Please enter the number that corresponds to the Genre of Movie"); 
            //Validate input
            while (!CorrectInput)
            {
                Input = Console.ReadLine();
                CorrectInput = DisplayText.HandleIntInput(Input, GenreMovieText, i);
            }
            NewMovie.Genre = (Genre)int.Parse(Input);
            CorrectInput = false;

            //Classification/Rating
            Console.WriteLine("Please enter the number that corresponds to the classification of the movie");
            i = 0;
            foreach (Classification str in Enum.GetValues(typeof(Classification)))
            {
                Console.WriteLine($"{i}. {str}");
                i++;
            }

            static void ClassificationMovieText() => Console.WriteLine("Please enter the number that corresponds to the Classification of Movie"); // function to repeat the text when handling bad input for genre
            //Validate input
            while (!CorrectInput)
            {
                Input = Console.ReadLine();
                CorrectInput = DisplayText.HandleIntInput(Input, ClassificationMovieText, i);
            }
            NewMovie.Classification = (Classification)int.Parse(Input);
            CorrectInput = false;

            //Date
            Console.WriteLine("Please enter the Release Date in dd/mm/yy format");
            NewMovie.ReleaseDate = Console.ReadLine();

            //Copies
            static void MovieCopiesText() => Console.WriteLine("Please enter the amount of copies of the DVD");
            MovieCopiesText();
            while (!CorrectInput)
            {
                Input = Console.ReadLine();
                CorrectInput = DisplayText.HandleIntInput(Input, MovieCopiesText, 10000);
            }
            NewMovie.Copies = int.Parse(Input);

            //inserts into array
            Program.Movies.Insert(NewMovie);

            Console.WriteLine("\n=============");
            Console.WriteLine("Movie Added.");
            Console.WriteLine("=============\n");

            //returns to staff menu
            DisplayText.StaffMenu();

        }

        public static void RemoveDVD() //removes dvd based on input
        {
            Console.WriteLine("Please enter movie title to be deleted");
            Node MovieNode = Program.Movies.FindNodeWithTitle(Console.ReadLine()); //finds node associated with movie title
            if (MovieNode != null)
            {
                Program.Movies.Remove(MovieNode.Movie); //deletes it
                Console.WriteLine("\n=============");
                Console.WriteLine("Movie Deleted.");
                Console.WriteLine("=============\n");
                DisplayText.StaffMenu();


            }
            else
            {
                Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Movie could not be found.");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!\n");
                DisplayText.StaffMenu();
            }
        }

        public static void RegisterMember()
        {
            Member NewMember = new Member();

            //First name
            Console.WriteLine("Please enter members first name");
            NewMember.FirstName = Console.ReadLine();

            //Last Name
            Console.WriteLine("Please enter members last name");
            NewMember.LastName = Console.ReadLine();
            NewMember.UserName = NewMember.LastName + NewMember.FirstName; //calculates username automatically

            //Address
            Console.WriteLine("Please enter users residential address");
            NewMember.Address = Console.ReadLine();

            //Phone Number
            Console.WriteLine("Please enter users phone number");
            NewMember.PhoneNumber = Console.ReadLine();

            //Password
            bool CorrectInput = false;
            string Input = "";
            static void PasswordText() => Console.WriteLine("Please enter their desired password"); // function to repeat the text when handling bad input for password
            PasswordText();
            //Validate input
            while (!CorrectInput)
            {
                Input = Console.ReadLine();
                CorrectInput = DisplayText.HandleIntInput(Input, PasswordText, 9999, 1000);
            }
            NewMember.Password = int.Parse(Input);

            //add to array
            Program.Members.InsertMember(NewMember);

            Console.WriteLine("\n=============");
            Console.WriteLine("Member Added.");
            Console.WriteLine("=============\n");

            DisplayText.StaffMenu();
        }

        public static void FindMember() //calls function to find member based on input of phone number
        {
            Console.WriteLine("Please Enter Members First and Last Name seperated by a space");
            string[] Input = Console.ReadLine().Split(" ");
            string UserName = Input[1] + Input[0];

            Console.WriteLine("\n=============");
            Console.WriteLine($"{Input[0]} {Input[1]}'s Phone Number is {Program.Members.SearchMemberNumber(UserName)}");
            Console.WriteLine("=============\n");

            DisplayText.StaffMenu();
        }
    }
}
