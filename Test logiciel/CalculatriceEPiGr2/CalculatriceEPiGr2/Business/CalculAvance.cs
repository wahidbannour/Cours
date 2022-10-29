using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatriceEPiGr2.Services;

namespace CalculatriceEPiGr2.Business
{
    public class CalculAvance
    {
        IEmail _email;
        IAuthentification _authentification;
        
        // injection de dépendance au niveau du constructeur
        public CalculAvance(IAuthentification authentification, IEmail email)
        {
            _email = email;
            _authentification = authentification; 
        }

        public void AddMatrix(int m1, int m2)
        {
            int s = m1 + m2;

            _email.SendMail(s.ToString());
        }
    }
}
