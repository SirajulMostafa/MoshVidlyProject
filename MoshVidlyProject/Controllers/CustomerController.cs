using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MoshVidlyProject.Models;

namespace MoshVidlyProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ServicesContext _context;

        public CustomerController()
        {
            _context = new ServicesContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=> c.MemberShipType).ToList();
            if (customers.Count == 0)
            {
                return Content("NOT DATA FOUND");
            }
            return View(customers);


        }

        public ActionResult Create()
        {

            return View();
        }


        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

      /*  private IEnumerable<Customer> getCustomers()
        {
            return 
        }*/
    }
}