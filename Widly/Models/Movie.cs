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
        [Required]
        [Range(1,20,ErrorMessage ="Number should be in the range of 1 to 20")]
        public int Stock { get; set; }
        public GenreType GenreType { get; set; }
        public byte GenreTypeId { get; set; }
    }
}