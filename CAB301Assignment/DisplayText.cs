using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CAB301Assignment
{
    class DisplayText
    {
        //main menu input handler
        #region MainMenu Logic
        public static void MainMenu()
        {
            MainMenuText();
            bool CorrectInput = false;
            string Input = "";

            //Validate input
            while (!CorrectInput)
            {
                Input = Console.ReadLine();
                CorrectInput = HandleIntInput(Input, MainMenuText, 2);
            }
            // Handle Where to go next based on the properly validated int
            switch (int.Parse(Input))
            {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1:
                    DisplayText.StaffLogin();
                    break;
                case 2:
                    DisplayText.MemberLogin();
                    break;
            }
        }
        
        private static void MainMenuText() //text for main menu
        {
            Console.WriteLine("Welcome to the Community Library");
            Console.WriteLine("============Main Menu==========");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("0. Exit");
            Console.WriteLine("================================");
            Console.WriteLine("Please make a selection (1-2, or 0 to exit)");
        }
        #endregion

        #region Staff Logic
        //Staff login input handler
        private static void StaffLogin()
        {
            Console.WriteLine("============Staff Login============");
            Console.WriteLine("Enter 0 in any of the fields to return to main menu.");
            Console.WriteLine("Please enter username");

            string UserName = Console.ReadLine();
            if(UserName == "0") { MainMenu(); }

            Console.WriteLine("Please enter Password");
            string Password = Console.ReadLine();

            if (Password == "0") { MainMenu(); }

            if(UserName == "staff" && Password == "today123")
            {
                StaffMenu();
            } else
            {
                Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Authentication Failed.");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!\n");
                StaffLogin();
            }
        }

        //staff menu input handler
        public static void StaffMenu()
        {
            StaffMenuText();
            bool CorrectInput = false;
            string Input = "";

            //Validate input
            while (!CorrectInput)
            {
                Input = Console.ReadLine();
                CorrectInput = HandleIntInput(Input, MainMenuText, 4);
            }
            // Handle Where to go next based on the properly validated int
            switch (int.Parse(Input))
            {
                case 0:
                    MainMenu();
                    break;
                case 1:
                    StaffMenuFunctions.AddMovie();
                    break;
                case 2:
                    StaffMenuFunctions.RemoveDVD();
                    break;
                case 3:
                    StaffMenuFunctions.RegisterMember();
                    break;
                case 4: StaffMenuFunctions.FindMember();
                    break;
            }
        }

        //text for staff menu
        private static void StaffMenuText()
        {
            Console.WriteLine("============Staff Menu==========");
            Console.WriteLine("1. Add New movie DVD");
            Console.WriteLine("2. Remove Movie DVD");
            Console.WriteLine("3. Register New Member");
            Console.WriteLine("4. Find a registered member's phone number");
            Console.WriteLine("0. Exit");
            Console.WriteLine("================================");
            Console.WriteLine("Please make a selection (1-4, or 0 to return to main menu)");
        }

        #endregion

        #region Member Logic

        //member login input handler
        private static void MemberLogin()
        {
            Console.WriteLine("============Member Login============");
            Console.WriteLine("Enter 0 in any of the fields to return to main menu.");
            Console.WriteLine("Please enter username");

            string UserName = Console.ReadLine();
            if (UserName == "0") { MainMenu(); }

            Console.WriteLine("Please enter Password");
            string Password = Console.ReadLine();

            if (Password == "0") { MainMenu(); }

            for (int i = 0; i < Program.Members.MembersArray.Length; i++)
            {
                if(Program.Members.MembersArray[i].UserName == UserName && Program.Members.MembersArray[i].Password.ToString() == Password)
                {
                    MemberMenu(Program.Members.MembersArray[i]);
                    break;
                }
            }
            Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("Authentication Failed");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!\n");
            MemberLogin();
        }

        //handle input for member menu
        public static void MemberMenu(Member Member)
        {
            MemberMenuText();
            bool CorrectInput = false;
            string Input = "";

            //Validate input
            while (!CorrectInput)
            {
                Input = Console.ReadLine();
                CorrectInput = HandleIntInput(Input, MemberMenuText, 5);
            }
            // Handle Where to go next based on the properly validated int
            switch (int.Parse(Input))
            {
                case 0:
                    MainMenu();
                    break;
                case 1:
                    MemberMenuFunctions.DisplayAllMovies(Member);
                    break;
                case 2:
                    MemberMenuFunctions.BorrowMovie(Member);
                    break;
                case 3:
                    MemberMenuFunctions.ReturnMovie(Member);
                    break;
                case 4:
                    MemberMenuFunctions.DisplayCurrentMovies(Member);
                    break;
                case 5:
                    MemberMenuFunctions.DisplayTopMovies(Member);
                    break;
            }
        }

        //text for member menu
        private static void MemberMenuText()
        {
            Console.WriteLine("============Member Menu==========");
            Console.WriteLine("1. Display all movies");
            Console.WriteLine("2. Borrow a movie DVD");
            Console.WriteLine("3. Return a movie DVD");
            Console.WriteLine("4. List current borrowed movies");
            Console.WriteLine("5. Display top 10 most popular movies");
            Console.WriteLine("0. Exit");
            Console.WriteLine("================================");
            Console.WriteLine("Please make a selection (1-5, or 0 to return to main menu)");
        }
        #endregion

        //Handles integer input for navigating between menus - returns true on valid input and recalls the text required on a invalid input.
        public static bool HandleIntInput(string Input, Action TextMethod, int MaxInput, int MinInput = 0)
        {
            if(!int.TryParse(Input, out int IntInput))
            {
                //non int
                Console.WriteLine($"Invalid Response please enter an integer between 0 and {MaxInput}");
                TextMethod(); //recall the text that needs to be displayed
                return false;
            }else if(IntInput < MinInput || IntInput > MaxInput)
            {
                // int out of bounds
                Console.WriteLine($"Invalid integer please enter an integer between 0 and {MaxInput}");
                TextMethod(); //recall the text that needs to be displayed
                return false;
            }
            return true;
        }
    }
}
