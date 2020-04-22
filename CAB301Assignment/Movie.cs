using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301Assignment
{
    public class Movie
    {
        public string Title;
        public List<string> Starring;
        public string Director;
        public int Length; //in mins
        public Genre Genre;
        public Rating Classification;
        public DateTime ReleaseDate;
        public int TimesBorrowed;
        public int Copies;
    }
}
