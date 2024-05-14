
//#pragma once



#ifndef DIGITAL_IO
#define DIGITAL_IO



struct IDigitalIo{
    
    virtual unsigned char DigitalRead(unsigned char address) = 0;
    virtual void DigitalWrite(unsigned char value, unsigned char address) = 0;
    
}; 

#endif
