using System;

namespace CAB301Assignment
{
    class Program
    {
        public static MemberCollection Members = new MemberCollection();
        public static MovieCollection Movies = new MovieCollection();

        static void Main(string[] args)
        {
            DisplayText.MainMenu();
        }
    }
}
