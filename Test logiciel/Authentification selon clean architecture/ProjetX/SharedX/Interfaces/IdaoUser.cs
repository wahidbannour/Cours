using SharedX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedX.Interfaces
{
    public interface IdaoUser
    {
        User GetUserByLogin(string login);
    }
}
