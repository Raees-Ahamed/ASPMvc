using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public int TelephoneNumber { get; set; }
    }
}
