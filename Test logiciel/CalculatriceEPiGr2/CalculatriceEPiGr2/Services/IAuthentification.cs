using CalculatriceEPiGr2.Models;

namespace CalculatriceEPiGr2.Services
{
    public interface IAuthentification
    {
        bool IsValidUser(User user);
    }
}