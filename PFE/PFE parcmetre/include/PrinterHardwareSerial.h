#pragma once
#include "PosPrinter.h"
#include "HardwareSerial.h"

class PrinterHardwareSerial : public IHardwareSerial{
    private :
        int x=0;
        HardwareSerial* _serial;

    public:
        PrinterHardwareSerial(HardwareSerial& serialUart);
        ~PrinterHardwareSerial();
        virtual void begin(int debit, int rx, int tx) override;
        virtual void print(String ) override;
        virtual void println(String ) override;
        virtual void write(const char* ) override;
};