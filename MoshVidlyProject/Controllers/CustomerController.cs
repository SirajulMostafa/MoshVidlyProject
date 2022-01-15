using System.Data.Entity;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Web.Mvc;
using MoshVidlyProject.Models;
using MoshVidlyProject.ViewModel;

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
        [HttpGet]
        public ActionResult Save()
        {
            var memberShipTypes = _context.MemberShipTypes.ToList();
            var viewModel = new CreateCustomerViewModel
            {
               Customer = new Customer(),
               MemberShipType = memberShipTypes,
                
            };

            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        //public ActionResult Create( CreateCustomerViewModel viewModel)
        public ActionResult Save( Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CreateCustomerViewModel
                {
                    Customer = new Customer(),
                    MemberShipType = _context.MemberShipTypes.ToList(),

                };

                return View("CustomerForm", viewModel);

            }
             
            if (customer.Id==0)
            {
                _context.Customers.Add(customer);

            }
            else
            {
                var customerDb = _context.Customers.Single(c => c.Id == customer.Id);
               // Mapper.Map(customer, customerDb);

                customerDb.Name = customer.Name;
                customerDb.Birthdate=customer.Birthdate;
                customerDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
         
            _context.SaveChanges();

            return RedirectToAction("Index","Customer");
        }


        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult Edit(int id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer==null)
                return HttpNotFound();

            var viewModel = new CreateCustomerViewModel
            {
                Customer = customer,
                MemberShipType =_context.MemberShipTypes.ToList()
            };

             return View("CustomerForm",viewModel);
        }

      /*  private IEnumerable<Customer> getCustomers()
        {
            return 
        }*/
    }
}