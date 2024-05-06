#include "../Domain/Services/DigitalIo/IDigitalIo.hpp"
//#include <Arduino.h>

class DigitalIoArduino : public IDigitalIo{
    public:
    virtual unsigned char digitalRead(unsigned char address) ;
    virtual void digitalWrite(unsigned char value, unsigned char address) ;

};