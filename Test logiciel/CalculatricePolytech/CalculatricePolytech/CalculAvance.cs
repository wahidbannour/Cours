using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;

namespace Calculatrice
{
    public class CalculAvance
    {
        IAuthentification authentification;
        IEmailManager mail = null;

        public IAuthentification Authentification { get => authentification; }

        public CalculAvance(IAuthentification authentification)
        {
            this.authentification  =  authentification;   
        }

        public CalculAvance(IAuthentification authentification, IEmailManager mail)
        {
            this.authentification = authentification;
            this.mail = mail;
        }

        public int ValeurAbsolue(int x)
        {
            if (!authentification.IsAuthentifie)
                throw new AuthenticationException("utilisateur non authentifé");
            return -x; 
        }

        public void CalculMatriciel(int x)
        {


            int resultat = x + 1; // simulation de calcul matriciel
                    mail.SendMail("calcul Matriciel", resultat);
        }
    }
}
