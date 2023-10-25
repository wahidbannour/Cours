#include <Arduino.h>
#include "BspLed.h"

void SystemConfig(){
  pinMode(LED, OUTPUT);     // Initialize the LED_BULTIN pin as an output
  //pinMode(D1, INPUT);
  Serial.begin(115200);
  Serial.println("TP1: Programme allume LED");
}

void InitApplication(){
  
  digitalWrite(LED,LED_OFF);

}


void setup() {
  // put your setup code here, to run once:
  SystemConfig();
  InitApplication();
}

void loop() {
  // put your main code here, to run repeatedly:
  digitalWrite(LED,LED_ON);
}

