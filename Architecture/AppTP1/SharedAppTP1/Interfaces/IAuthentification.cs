﻿using SharedAppTP1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAppTP1.Interfaces
{
    public interface IAuthentification
    {
        User VerifyUser(string login, string password);

        bool IsVerified { get; }
    }
}
