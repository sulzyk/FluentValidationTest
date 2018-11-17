using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationTest
{
    public class UserRepository : IUserRepository
    {
        public bool Exist(string email)
        {
            return true;
        }
    }
}
