

struct IDigitalIo{

    virtual unsigned char digitalRead(unsigned char address) = 0;
    virtual void digitalWrite(unsigned char value, unsigned char address) =0;

};