#include <HardwareSerial.h>

#define ESC 0x1b
#define GS 0x1d

enum Justification
{
    Left =0,
    Center = 1,
    Right = 2
};

class IHardwareSerial{
    public:
        virtual void begin(int debit, int rx, int tx)= 0;
        virtual void print(String )=0;
        virtual void println(String )=0;
        virtual void write(const char* )=0;
};


class PosPrinter{
    private:
        IHardwareSerial* _serialInterface;
    public:
        PosPrinter(IHardwareSerial& serialInterface);
        void InitPrinter();
        void SelectPageMode();
        void SelectStandardMode();
        void JustifyText(Justification justification);
        void PrintAndFeedPaper(char lines);
        void SetHorizontalAndVerticalMotion(char x, char y);
        void Print(String text);

};