#include "DigitalIoArduino.hpp"
#include <Arduino.h> // la bibliothèque "Arduino" doit être inclus en utilisant <>



unsigned char DigitalIoArduino::DigitalRead(unsigned char address)  {
    return digitalRead(address*3);
}

void DigitalIoArduino::DigitalWrite(unsigned char value, unsigned char address) {
    digitalWrite(value, address);
}