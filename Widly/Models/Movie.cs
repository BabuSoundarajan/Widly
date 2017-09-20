using System;

namespace Widly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int Stock { get; set; }
        public GenreType GenreType { get; set; }
    }
}