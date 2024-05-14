
#include "BspLed.hpp"
// l'utilisation des <> force platformio de compiler chaque bilbiothèque appelée
// ceci doit être suivi dans tout le projet
#include <ValueObject/DigitalOutputs.hpp> 
#include <Services/DigitalIo/IDigitalIo.hpp>
#include <DigitalIo/DigitalIoArduino.hpp>
#include <CommandLed.hpp>
#include <Arduino.h>

// function declarations 
void configSystem();
void configApplication();

// global variable and object instanciation 
DigitalIoArduino washbowIo;

 CommandLed  commandLed {washbowIo};
 Outputs out;
 LedLogicCommand ledCommand;

// setup arduino framework
void setup() {
  // put your setup code here, to run once:
  configSystem();
  configApplication();
  // pour avoir un écho de débogage sur la console du PC
  Serial.begin(115200);
  Serial.println("programme led ");
  //currentTime = millis();
}

// loop arduino framework
void loop() {
        if (commandLed.LedState == LightOff) {

          commandLed.ActivateLight();  // Turn on the LED
        } else {
          commandLed.DiactivateLight();   // Turn off the LED
        }
      
}

//method implementation
void configSystem()
{
  // Digital IO
  
  pinMode(LIGHT_BUTTON,INPUT_PULLDOWN);
  pinMode(LIGHT,OUTPUT);

}

void configApplication()
{
  //ici on fait la concrétisation de l'abstraction faite au niveau
  // de la classe CommandLed et on défini les entrées/sorties réels
  // de notre système en se référent d'une part au framework via washbowIo
  // (passé par référence à l'instance de LedCommand dans son constructeur)
  // et en utilisant le fichier de BspLed.
  out.Led = LIGHT;
  ledCommand.LedOn = LIGHTON;
  ledCommand.LedOff = LIGHTOFF;
  commandLed.Configure(out,ledCommand);
  commandLed.DiactivateLight();
}
