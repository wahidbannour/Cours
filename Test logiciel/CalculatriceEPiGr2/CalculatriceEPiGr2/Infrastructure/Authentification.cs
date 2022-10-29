using CalculatriceEPiGr2.Models;
using CalculatriceEPiGr2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatriceEPiGr2.Infrastructure
{
    public class Authentification : IAuthentification
    {
        // MysqlData : un objet de dépendence avec l'infrastructure Mysq DB
        // 


        public bool IsValidUser(User user)
        {
            if (user == null) return false;

            //if(user.Login == dbUser.Login && user.Password == dbUser.Password)
            //    return true;
            //return false;
            //.... du code à écrire.....


            return false;

        }
    }
}
