#include "bsp.h"
#include <Arduino.h>
#ifdef Version_1

void InitSystem();
void InitApplication();
void MyProgram();

void setup() {
  // put your setup code here, to run once:
  InitSystem();
  InitApplication();
}

void InitSystem(){
  Serial.begin(115200);
  pinMode(LED, OUTPUT);
  pinMode(BP, INPUT_PULLUP);
}

void InitApplication(){
  digitalWrite(LED , LED_OFF);
}

void MyProgram(){
  if(digitalRead(BP) == BP_APPUYE){
    digitalWrite(LED,LED_ON);
    delay(500);
    digitalWrite(LED,LED_OFF);
    delay(500);
  }
    
  else{
    digitalWrite(LED,LED_OFF);
  }

}
void loop() {
  // put your main code here, to run repeatedly:
  
  MyProgram();
    
  delay(10); // this speeds up the simulation
}

#endif