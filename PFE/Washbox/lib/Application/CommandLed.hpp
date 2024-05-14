
#ifndef COMMAND_LED
#define COMMAND_LED

#include <ValueObject/DigitalOutputs.hpp>
#include <Services/DigitalIo/IDigitalIo.hpp>

enum LedStates{
    LightOff,
    LightOn,
};

/// @brief classe business pour implémenter
/// la logique de commande d'une façon abstraite du hardware.
/// On a fait recours aux valueObject du domaine pour manipuler
/// les entrées/sorties d'une façon indépendante du hardware et du framework
class CommandLed{
    private:
     IDigitalIo* io;
     Outputs out;
     LedLogicCommand ledCommand;
     public:
    LedStates LedState;

    void ActivateLight();
    void DiactivateLight();
    
     CommandLed(IDigitalIo& io);
     /// @brief configure est la méthode qui permet de configurer
     /// la classe CommandLed
     /// RQ : une autre alternative aurait été l'utilisation du 
     /// constructeur pour passer la configuration, mais dans ce cas
     /// il faut que les objets à passer doivent être créées et configurées
     /// alors que si on regarde le fichier "main.cpp" on voit bien que
     /// cette classe est instancié statiquement tandisque la configuration
     /// ne sera prête qu'au moment de l'appel de la méthode "setup()".
     /// @param out 
     /// @param ledCommand 
     void Configure(Outputs& out, LedLogicCommand& ledCommand);
};
 #endif