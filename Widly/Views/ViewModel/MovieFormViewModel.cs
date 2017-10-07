using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Widly.Models;

namespace Widly.Views.ViewModel
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Stock = movie.Stock;
            GenreTypeId = movie.GenreTypeId;
           
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public IEnumerable<GenreType> GenreTypes { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }
        [Required]
        [Range(1, 20, ErrorMessage = "Number should be in the range of 1 to 20")]
        public int Stock { get; set; }
        public GenreType GenreType { get; set; }
        [Required]
        public byte GenreTypeId { get; set; }

        
    }
}