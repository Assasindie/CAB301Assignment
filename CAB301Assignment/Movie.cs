using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301Assignment
{
    public class Movie
    {
        public string Title;
        public string[] Starring;
        public string Director;
        public int Length; //in mins
        public Genre Genre;
        public Classification Classification;
        public string ReleaseDate;
        public int TimesBorrowed = 0;
        public int Copies;
    }
}
