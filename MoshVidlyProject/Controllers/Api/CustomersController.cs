using AutoMapper;
using MoshVidlyProject.Dto;
using MoshVidlyProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace MoshVidlyProject.Controllers.Api
{
    public class CustomersController : ApiController
    {


        private readonly ServicesContext _db;
        public CustomersController()
        {
            _db = new ServicesContext();
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
        // GET:/api/ Customer
        public IHttpActionResult GetCustomers()
        {
            var customers = _db.Customers.
                Include(c=>c.MemberShipType)
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
            return Ok(customers);
        }
        //GET /api Customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _db.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
             return NotFound(); 
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));

        }
        //POST /api/customers
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
               return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _db.Customers.Add(customer);
            _db.SaveChanges();
            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);

        }
        //PUT /api/customer/1
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customerInDb = _db.Customers.SingleOrDefault(c=>c.Id==id);
            if (customerInDb == null)
                return NotFound();
                // throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
/*
            customerInDb.Name = customerDto.Name;
            customerInDb.Birthdate = customerDto.Birthdate;
            customerInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
            customerInDb.MemberShipTypeId = customerDto.MemberShipTypeId;*/
            _db.SaveChanges();
            return Ok();
        }
        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _db.Customers.SingleOrDefault(c=>c.Id==id);
            if (customerInDb == null)
                return NotFound();

               // throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            _db.Customers.Remove(customerInDb);
            _db.SaveChanges();
            return Ok();
        }
    }
}