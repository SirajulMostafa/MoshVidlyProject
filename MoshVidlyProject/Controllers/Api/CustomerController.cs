using MoshVidlyProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MoshVidlyProject.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private ServicesContext db = new ServicesContext();

        // GET:/api/ Customer
        public IEnumerable<Customer> getCustomers()
        {
            return db.Customers.ToList();
           
        }
        //GET /api Customers/1
        public Customer GetCustomer(int Id)
        {
            var customer = db.Customers.SingleOrDefault(x => x.Id == Id);
            if (customer == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            return customer;

        }
        //POST /api/customers
        [System.Web.Http.HttpPost]
        public Customer CreatCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            db.Customers.Add(customer);
            db.SaveChanges();

            return customer;


        }
        //PUT /api/customer/1
        [HttpPut]
        public void UpdateCustomer(int Id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            var customerInDb = db.Customers.SingleOrDefault(c=>c.Id==Id);
            if (customerInDb == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
        
              customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
            db.SaveChanges();
                    }
        // DELETE   /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            var customerinDb = db.Customers.SingleOrDefault(c=>c.Id==Id);
            if (customerinDb == null)

                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            db.Customers.Remove(customerinDb);
            db.SaveChanges();
}
    }
}