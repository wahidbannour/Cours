#include <Arduino.h>
#include "chenillard.h"
#include "bsp.h"

enum ChenillardStates {
  CycleA,
  CycleB,
  CycleC
};

enum LedStates {
  LedOn,
  LedOff
};


hw_timer_t *cycle_timer = NULL;
hw_timer_t *blink_timer = NULL;
portMUX_TYPE cycleTimerMux = portMUX_INITIALIZER_UNLOCKED;
portMUX_TYPE blinkTimerMux = portMUX_INITIALIZER_UNLOCKED;
ChenillardStates chenillardState;
LedStates ledState;
volatile bool blinkFlag =false;
volatile bool cylceFlag = false;
// put function declarations here:
void SystemConfig();
void ApplicationConfig();
void FsmChenillard();
void FsmBlink();
void TimerConfig();
void DigitalIoConfig();


void IRAM_ATTR OnCycleEnd(){
  portENTER_CRITICAL(&cycleTimerMux);
  cylceFlag = true;
  portEXIT_CRITICAL(&cycleTimerMux);
}

void IRAM_ATTR OnBlinkEnd(){
  portENTER_CRITICAL(&blinkTimerMux);
  blinkFlag = true;
  portEXIT_CRITICAL(&blinkTimerMux);
}


void setup() {
  // put your setup code here, to run once:
  SystemConfig();
  ApplicationConfig();
}

void loop() {
  // put your main code here, to run repeatedly:
  FsmChenillard();
  FsmBlink();
  delay(5); // update time of the FSM
}

void SystemConfig(){
  Serial.begin(115200);
  TimerConfig();
  DigitalIoConfig();
}

void TimerConfig(){
  cycle_timer = timerBegin(0, 80, true);  // 1 µs par impulsion
  timerAttachInterrupt(cycle_timer, &OnCycleEnd, true);
  timerAlarmWrite(cycle_timer, THIRTY_SECOND, true);
  //

  blink_timer = timerBegin(1, 80, true);
  timerAttachInterrupt(blink_timer, &OnBlinkEnd, true);
  timerAlarmWrite(blink_timer, ONE_HZ, true);
  //
}

void DigitalIoConfig(){
  pinMode(LED,OUTPUT);
}

void ApplicationConfig(){
  Serial.println("Init App");
  digitalWrite(LED,LED_ON);
  chenillardState = ChenillardStates::CycleA;
  ledState =LedStates::LedOff;
  timerAlarmEnable(cycle_timer);
  timerAlarmEnable(blink_timer);
  delay(1000);
  digitalWrite(LED,LED_OFF);
  Serial.println("End Init App");
  Serial.println("Cycle A");
}

void FsmChenillard(){
  switch(chenillardState){
    case ChenillardStates::CycleA:
      if(cylceFlag)
      {
        cylceFlag = false;
        chenillardState = ChenillardStates::CycleB;
        timerAlarmDisable(blink_timer);
        timerAlarmWrite(blink_timer, TEN_HZ, true);
        timerAlarmEnable(blink_timer);
        Serial.println("Cycle B");
      }
      break;
    case ChenillardStates::CycleB:
      if(cylceFlag)
      {
        cylceFlag = false;
        chenillardState = ChenillardStates::CycleC;
        timerAlarmDisable(blink_timer);
        timerAlarmWrite(blink_timer, FIFTY_HZ, true);
        timerAlarmEnable(blink_timer);
        Serial.println("Cycle C");
      }
      break;
    case ChenillardStates::CycleC:
      if(cylceFlag)
      {
        cylceFlag = false;
        chenillardState = ChenillardStates::CycleA;
        timerAlarmDisable(blink_timer);
        timerAlarmWrite(blink_timer, ONE_HZ, true);
        timerAlarmEnable(blink_timer);
        Serial.println("Cycle A");
      }
      break;
  }
}

void FsmBlink(){
  switch(ledState){
    case LedStates::LedOn:
      
      if(blinkFlag){
        blinkFlag = false;
        digitalWrite(LED,LED_OFF);  
        ledState = LedStates::LedOff;
        Serial.println("Led Off");
      }
      break;
    case LedStates::LedOff:
      
      if(blinkFlag){
        blinkFlag = false;
        digitalWrite(LED,LED_ON);  
        ledState = LedStates::LedOn;
        Serial.println("Led On");
      }
      break;
  }
}
