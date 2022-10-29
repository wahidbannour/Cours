using CalculatriceEPiGr2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatriceEPiGr2.Infrastructure
{
    internal class Email : Services.IEmail
    {
        User user;

        //ServerMail server;
        public Email (User user)
        {
            this.user = user;
            //server = new ServerMail();
        }

        public void SendMail(string Message)
        {
            // connecter au serveur email
            //server.Connect("yahoo.fr");
            // parametrer le message
            //server.Message = Message;
            // envoyer le message
            //server.Send();

        }
    }
}
