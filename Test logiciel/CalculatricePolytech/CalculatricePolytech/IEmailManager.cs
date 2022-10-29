using System;
using System.Collections.Generic;
using System.Text;

namespace Calculatrice
{
    public interface IEmailManager
    {
       void SendMail(string subject, int resultat);
    }
}
