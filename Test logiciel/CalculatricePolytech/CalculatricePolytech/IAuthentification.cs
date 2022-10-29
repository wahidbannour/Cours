using System;
using System.Collections.Generic;
using System.Text;

namespace Calculatrice
{
    public interface IAuthentification
    {
        bool Authentifier(User user);
        bool IsAuthentifie { get; }
    }
}
