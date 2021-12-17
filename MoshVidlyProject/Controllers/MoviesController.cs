using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoshVidlyProject.Models;
using MoshVidlyProject.ViewModel;

namespace MoshVidlyProject.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek?"};
            var customers  = new List<Customer>()
            {
                new Customer(){Name = "Customer 1"},
                new Customer(){Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,//initialized value//pass the movie object
                Customers = customers
            };
             
            return View(viewModel);
        }
        public ActionResult ByReleaseDate(int year, int month)
        {

            return Content(year+"/"+month);
        }
        
    }
}