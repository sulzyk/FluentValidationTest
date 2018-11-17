using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationTest
{
    public interface IUserRepository
    {
        bool Exist(string email);
    }
}
