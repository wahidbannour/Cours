// See https://aka.ms/new-console-template for more information
using CoreX;
using InfrastructureX;

Console.WriteLine("Hello, World application X!");

Console.WriteLine("Donner votre login : ");
var login = Console.ReadLine();
Console.WriteLine("Donner votre mot de passe :");
var pwd = Console.ReadLine();

var authentification = new Authentification(new DaoUser());
if (authentification.VerifyUser(login, pwd))
    Console.WriteLine("Bienvenue : {0} " , authentification.CurrentUser.Name);
else
    Console.WriteLine("Erreur d'authentification");