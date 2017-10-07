using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Widly.Dtos;
using Widly.Models;

namespace Widly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _applicationDbContext;

        public CustomersController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        //GET /Api/Customers

        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _applicationDbContext.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        //GET /Api/Customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _applicationDbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        //POST /Api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _applicationDbContext.Customers.Add(customer);
            _applicationDbContext.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto);

        }

        //PUT /Api/Customers/1

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _applicationDbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto,customerInDb);

            _applicationDbContext.SaveChanges();
        }

        //DELETE /Api/cusomters/1
        public void DeleteCustomer(int id)
        {
            var customerInDb = _applicationDbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _applicationDbContext.Customers.Remove(customerInDb);
        }
    }
}
