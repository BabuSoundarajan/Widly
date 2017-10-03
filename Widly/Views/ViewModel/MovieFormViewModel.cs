using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Widly.Models;

namespace Widly.Views.ViewModel
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<GenreType> GenreTypes { get; set; }
    }
}