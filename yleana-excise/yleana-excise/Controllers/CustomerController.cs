using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using yleana_excise.web_api.Models;
using yleana_excise.web_api;


namespace yleana_excise.Controllers
{
    public class CustomerController : ApiController
    {
        // GET api/customer
        public IEnumerable<Customer> Get()
        {
            var cust = CustomerRepository.GetCustomers();
            return cust.ToList();
        }

        // GET api/customer/5
        public Customer Get(int id)
        {
            return CustomerRepository.GetCustomers().Where((c) => c.CustomerID == id).FirstOrDefault();
        }

        // POST api/customer
        public HttpResponseMessage Post(Customer value)
        {
            CustomerRepository.AddCustomer(value);

            var response = Request.CreateResponse<Customer>(HttpStatusCode.Created, value);

            string uri = Url.Link("DefaultApi", new { id = value.CustomerID });
            response.Headers.Location = new Uri(uri);

            return response;
        }

    }
}
