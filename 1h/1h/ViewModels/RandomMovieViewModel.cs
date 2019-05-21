using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _1h.Models;

namespace _1h.ViewModels { 
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<custumer> custumers { get; set; }
    }
}