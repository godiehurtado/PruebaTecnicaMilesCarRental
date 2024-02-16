using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental_Api.Model
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public string Licence { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
