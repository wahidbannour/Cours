#include <Arduino.h>


#define LED 2
#define HALF_SECOND 500000
#define MAX_HEART_BEAT_TIMER_LOAD  2

int heartBeatTimerLoader ;
hw_timer_t *heartBeat_timer = NULL;



void IRAM_ATTR onHeartBeatTimer(){
  
  heartBeatTimerLoader--;
  if(heartBeatTimerLoader==0)
  {
    digitalWrite(LED, HIGH);
    heartBeatTimerLoader = MAX_HEART_BEAT_TIMER_LOAD;  
  }
  else
  {
    digitalWrite(LED,LOW);
  }

}



void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  Serial.println("start config");
  pinMode(LED,OUTPUT);

  heartBeatTimerLoader = MAX_HEART_BEAT_TIMER_LOAD;
  
  heartBeat_timer = timerBegin(0, 80, true);
  timerAttachInterrupt(heartBeat_timer, &onHeartBeatTimer, true);
  timerAlarmWrite(heartBeat_timer, HALF_SECOND, true);
  timerAlarmEnable(heartBeat_timer);
  
}

void loop() {
  // put your main code here, to run repeatedly:
  Serial.println("LEd state ");
  Serial.print(digitalRead(LED));
  delay(500);
}