using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationTest
{
    public class User
    {
        public User()
        {
            Address = new Address();
            Order = new List<Order>();
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool CreateInvoice { get; set; }

        public string Nip { get; set; }

        public Address Address { get; set; }

        public IEnumerable<Order> Order { get; set; }

        
    }
}
