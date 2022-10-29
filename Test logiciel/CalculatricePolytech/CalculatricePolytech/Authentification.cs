using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Calculatrice
{
    public class Authentification : IAuthentification
    {
        bool _isAuthentife = false;

        public bool IsAuthentifie => _isAuthentife;

        public bool Authentifier(User user)
        {
            // implémente la vrai dépendance avec DaoUser...
            throw new NotImplementedException();
        }
    }
}
