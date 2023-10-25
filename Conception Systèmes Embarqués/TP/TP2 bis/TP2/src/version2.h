#include "bsp.h"
#include <Arduino.h>

#ifdef Version_2


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
  
  pinMode(LED1, OUTPUT);
  pinMode(BP1, INPUT_PULLUP);
  
  pinMode(LED2, OUTPUT);
  pinMode(BP2, INPUT_PULLUP);
}

void InitApplication(){
  digitalWrite(LED1 , LED_OFF);
  digitalWrite(LED2 , LED_OFF);
}

void MyProgram(){
  if(digitalRead(BP1) == BP_APPUYE){
    digitalWrite(LED1,LED_ON);
    delay(500);
    digitalWrite(LED1,LED_OFF);
    delay(500);
  }
    
  else{
    digitalWrite(LED1,LED_OFF);
  }

  if(digitalRead(BP2) == BP_APPUYE){
    digitalWrite(LED2,LED_ON);
    delay(2000);
    digitalWrite(LED2,LED_OFF);
    delay(2000);
  }
    
  else{
    digitalWrite(LED1,LED_OFF);
  }

}
void loop() {
  // put your main code here, to run repeatedly:
  
  MyProgram();
    
  delay(10); // this speeds up the simulation
}

#endif