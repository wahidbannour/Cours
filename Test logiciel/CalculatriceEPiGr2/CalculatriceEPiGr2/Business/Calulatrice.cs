using CalculatriceEPiGr2.Models;
using CalculatriceEPiGr2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatriceEPiGr2.Business
{
    public class Calculatrice
    {
        IAuthentification authentification;

        public Calculatrice(IAuthentification authentification)
        {

            this.authentification = authentification;
        }


        public int Add(int x, int y,User user)
        {
            if (authentification.IsValidUser(user))
                return x + y;
            else
                throw new ArgumentException("Authentification refusé");
        }
    }
}
