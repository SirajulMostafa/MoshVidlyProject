using System.Collections.Generic;
using System.Web.Mvc;
using MoshVidlyProject.Models;
using MoshVidlyProject.ViewModel;

namespace MoshVidlyProject.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            var movie = new Movie() { Name = "Shrek?" };
            var customers = new List<Customer>()
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

        public ActionResult Details(int id)
        {

            return Content("hello details");
        }
    }
}