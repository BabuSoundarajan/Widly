using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        public IEnumerable<Customer> GetCustomers()
        {
            return _applicationDbContext.Customers.ToList();
        }

        //GET /Api/Customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _applicationDbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        //POST /Api/Customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _applicationDbContext.Customers.Add(customer);
            _applicationDbContext.SaveChanges();

            return customer;
        }

        //PUT /Api/Customers/1

        [HttpPut]
        public Customer UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _applicationDbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.Name = customer.Name;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.BirthDate = customer.BirthDate;

            return customer;
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
