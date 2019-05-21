using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _1h.Models;
using _1h.ViewModels;

namespace _1h.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "NomeFilme!"};

            var custumers = new List<custumer>
            {
                new custumer{ Name = "custumer 1"},
                new custumer{ Name = "custumer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                custumers = custumers
            };
            return View(viewModel);
        }

        public JsonResult GravarJson(string nome)
        {
            JsonResult json = new JsonResult();
            var custumer = new custumer { Name = nome };
            json.Data = custumer;
            return json;
        }
    }
}