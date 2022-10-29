using System;
using System.Collections.Generic;
using System.Text;

namespace Calculatrice
{
    public class EMailManager : IEmailManager
    {
        User _user;

        public EMailManager(User user)
        {
            _user = user;
        }

        public void SendMail(string subject, int resultat)
        {
            throw new NotImplementedException();
        }
    }
}
