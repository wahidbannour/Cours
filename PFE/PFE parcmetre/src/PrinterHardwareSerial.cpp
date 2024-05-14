#include "PrinterHardwareSerial.h"


PrinterHardwareSerial::PrinterHardwareSerial(HardwareSerial& serialUart)
{
    _serial = &serialUart;
}

PrinterHardwareSerial::~PrinterHardwareSerial(){
    _serial->end(true);
}


void PrinterHardwareSerial::begin(int debit, int rx, int tx){
    _serial->begin(debit,SERIAL_8N1, rx,tx);
}
void PrinterHardwareSerial::print(String s ){
    _serial->print(s);
}
void PrinterHardwareSerial::println(String s){
    _serial->println(s);
}
void PrinterHardwareSerial::write(const char* bytes){
    _serial->write(bytes);
}