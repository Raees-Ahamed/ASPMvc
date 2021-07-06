using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public interface ICustomerData
    {
        IEnumerable<Customer> GetAllCustomers();
        void CreateCustomer(Customer customer);

        Customer Get(int id);
    }
}
