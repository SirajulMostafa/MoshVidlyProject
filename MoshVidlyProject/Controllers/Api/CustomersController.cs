using AutoMapper;
using MoshVidlyProject.Dto;
using MoshVidlyProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MoshVidlyProject.Controllers.Api
{
    public class CustomersController : ApiController
    {


        private  ServicesContext db;
        public CustomersController()
        {
            db = new ServicesContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        // GET:/api/ Customer
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customers = db.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
            return customers;
        }
        //GET /api Customers/1
        public CustomerDto GetCustomer(int Id)
        {
            var customer = db.Customers.SingleOrDefault(x => x.Id == Id);
            if (customer == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            return Mapper.Map<Customer,CustomerDto>(customer);

        }
        //POST /api/customers
        [System.Web.Http.HttpPost]
        public CustomerDto CreatCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            db.Customers.Add(customer);
            db.SaveChanges();
            customerDto.Id = customer.Id;

            return customerDto;


        }
        //PUT /api/customer/1
        [HttpPut]
        public void UpdateCustomer(int Id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            var customerInDb = db.Customers.SingleOrDefault(c=>c.Id==Id);
            if (customerInDb == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
/*
            customerInDb.Name = customerDto.Name;
            customerInDb.Birthdate = customerDto.Birthdate;
            customerInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
            customerInDb.MemberShipTypeId = customerDto.MemberShipTypeId;*/
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