using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoshVidlyProject.Models;

namespace MoshVidlyProject.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek?"};
            return View(movie);
        }
        public ActionResult ByReleaseDate(int year, int month)
        {

            return Content(year+"/"+month);
        }
        
    }
}