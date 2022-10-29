// See https://aka.ms/new-console-template for more information
using CalculatriceEPiGr2.Business;
using CalculatriceEPiGr2.Infrastructure;
using CalculatriceEPiGr2.Models;


Console.WriteLine("Hello, World!");
var calculatrice = new Calculatrice(new Authentification());
try
{
    calculatrice.Add(5, 2, new User { Id = 1 });
}
catch (ArgumentException)
{

    Console.WriteLine("Erreur d'authentification");
}