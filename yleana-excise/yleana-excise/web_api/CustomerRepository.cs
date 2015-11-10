using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yleana_excise.web_api.Models;
 
namespace yleana_excise.web_api
{
    
    public class CustomerRepository  
    {
        public static IEnumerable<Customer> GetCustomers()
        {
            var myDB = new CustomerModel();
            var query = from cust in myDB.Customers
                        select cust;

            return query.ToList();
        }

        public static int AddCustomer(Customer customer)
        {
            using (var db = new CustomerModel())
            {
                var row = new Customer
                {
                    CustomerName = customer.CustomerName,
                    ContactName = customer.ContactName,
                    Address = customer.Address,
                    City = customer.City,
                    PostalCode = customer.PostalCode,
                    Country = customer.Country
                };

                db.Customers.Add(row);
                db.SaveChanges();

                return row.CustomerID;
            }
        }

    }
}