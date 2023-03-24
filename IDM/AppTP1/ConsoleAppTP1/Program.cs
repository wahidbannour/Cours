// See https://aka.ms/new-console-template for more information
using AppCore;
using InfrastructureAppTp1;
using SharedAppTP1.Interfaces;

Console.WriteLine("Hello, World for App TP1!");
Console.Write("Donner votre login : ");
string login = Console.ReadLine();

Console.Write("Donner votre mot de passe : ");
string psswrd = Console.ReadLine();

IAuthentification authentification = new Authentification(new DaoUserInMemoryDB());
var user = authentification.VerifyUser(login, psswrd);
if(authentification.IsVerified)
{
    Console.WriteLine("Bienvenue : {0} ", user.Name);
}
else
{
    Console.WriteLine("Désolé, votre authentification incorrecte...");
}