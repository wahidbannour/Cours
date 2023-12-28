#include <Arduino.h>


#define STATE       2
#define EN_485      5
#define BUZ_Alarm   13
#define ENABLE      14
#define IN_AUX      12
#define Rx_485      16
#define Tx_485      17
#define L1          18
#define L2          19
#define L3          21
#define L4          23
#define AUX_RELAY1  22
#define AUX_RELAY2   4
#define ALARM_IN    25
#define SENSOR1     32
#define SENSOR2     27
#define SENSOR3     33
#define SENSOR4     26
#define ORD1        34
#define ORD2        35
#define ORD3        36
#define ORD4        39


// Control Logic Input
#define IS_ACTIVATED   HIGH
#define IS_RELEASED    LOW

#define IS_OPENED     LOW
#define IS_CLOSED     HIGH

// Control Logic Output

#define OPEN        HIGH
#define CLOSE       LOW
