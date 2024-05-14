#include "PosPrinter.h"




PosPrinter::PosPrinter(IHardwareSerial& serialInterface)
{
    _serialInterface = &serialInterface;
}

void PosPrinter::InitPrinter()
{
    char command[2]= { ESC, '@' };
    _serialInterface->write(command);
}
void PosPrinter::SelectPageMode()
{
    char command[2]= { ESC, 'L' };
    _serialInterface->write(command);
}
void PosPrinter::SelectStandardMode()
{
    char command[2]= { ESC, 'S' };
    _serialInterface->write(command);
}
void PosPrinter::SetHorizontalAndVerticalMotion(char x, char y)
{
    char command[4]= { GS, 'P', x ,y };
    _serialInterface->write(command);
}

void PosPrinter::JustifyText(Justification justification)
{
    char command[3]= { ESC,'a', (char)justification};
    _serialInterface->write(command);
}
void PosPrinter::PrintAndFeedPaper(char lines)
{
    char command[3]= { ESC, 'J', lines };
    _serialInterface->write(command);
}
void PosPrinter::Print(String text)
{
    _serialInterface->println(text);
}

