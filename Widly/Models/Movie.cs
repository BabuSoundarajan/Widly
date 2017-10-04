using System;
using System.ComponentModel.DataAnnotations;

namespace Widly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        [Display(Name ="Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }
        public int Stock { get; set; }
        public GenreType GenreType { get; set; }
        public byte GenreTypeId { get; set; }
    }
}