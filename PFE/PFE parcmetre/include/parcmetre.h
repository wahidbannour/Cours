#include "BspDevkitV1.h"

#define PRINTER_TX UART2_TX
#define PRINTER_RX UART2_RX 

#define CONSOLE_TX UART0_TX
#define CONSOLE_RX UART0_RX


#define HALF_SECOND  500000
#define DEFIL_TIME   300000
#define PRESSED     0
#define RELEASED    1
#define MAX_INPUTS  7

#define INPUT_BOUTON_1 0
#define INPUT_BOUTON_2 1
#define INPUT_BOUTON_3 2
#define INPUT_VALID    3
#define INPUT_COIN_CH1 4
#define INPUT_COIN_CH2 5
#define INPUT_COIN_CH3 6

enum lcdStates{

    idleLcd ,
    defilement,
};

enum monayeurStates{
    idleMon ,
    lecture,
};

enum parcmetreStates{
    idleParc ,
    initParc,
    waitingForChoice,
    waitingForValidation,
    calculation,
    waitingForMoney,
    printing,
    waitForPrinter,

};

