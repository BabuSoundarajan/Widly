using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Widly.Dtos
{
    public class MovieDto
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Number should be in the range of 1 to 20")]
        public int Stock { get; set; }

        [Required]
        public byte GenreTypeId { get; set; }
    }
}