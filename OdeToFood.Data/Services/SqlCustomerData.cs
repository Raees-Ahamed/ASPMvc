using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class SqlCustomerData : ICustomerData
    {
        private readonly Data db;

        public SqlCustomerData(Data db)
        {
            this.db = db;
        }

        public void CreateCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public Customer Get(int id)
        {
            var customer = db.Customers.FirstOrDefault(c => c.Id == id);
            return customer;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return db.Customers.OrderBy(c => c.Name);
        }
    }
}
