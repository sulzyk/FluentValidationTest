using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User()
            {
                Email = "asdasd@aawe.net",
                CreateInvoice = true,
                Nip = "123",
                Order = new List<Order>
                {
                    new Order()
                }
            };

            var validator = new UserValidator(new UserRepository());

            var result = validator.Validate(user);

            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"{error.PropertyName}: {error.ErrorMessage}");
                }
            }
        }
    }
}
