/*
Author : Wahid Bannour
Organisation : ISET Mahdia, IT Department
Date : Mai 2023
Project : Oscilloscope 
*/

#include <Arduino.h>
#include "oscilloscope.h"


#include <RingBuffer.h>
//#include "../lib/RingBuffer/RingBuffer.h"

void ApplicationConfig();


RingBuffer rBuffer(MAX_LENGTH_BUFFER); 
portMUX_TYPE bufferWriteMux = portMUX_INITIALIZER_UNLOCKED;
mutex readInputsMux ;
hw_timer_t *heartBeat_timer = NULL;
hw_timer_t *sampling_timer = NULL;
int heartBeatTimerLoader;
char channelValues[MAX_BUFFER_INPUT]; // every channel is a bit in a byte. Channel0 -> bit0
int channels[MAX_CHANNELS]={CHANNEL0,CHANNEL1,CHANNEL2,CHANNEL3,CHANNEL4,CHANNEL5};
volatile int currentInputIndex=0;
int currentOutputIndex=0;
char bufferOutput[MAX_BUFFER_OUTPUT];


void IRAM_ATTR onHeartBeatTimer(){
  
  heartBeatTimerLoader--;
  if(heartBeatTimerLoader==0)
  {
    digitalWrite(BOARD_STATE, HIGH);
    heartBeatTimerLoader = MAX_HEART_BEAT_TIMER_LOAD;  
  }
  else
  {
    digitalWrite(BOARD_STATE,LOW);
  }

}

void IRAM_ATTR OnOneMsTimer(){
  readInputsMux.lock();
  char value = 0;
  for (int i = 0; i < MAX_CHANNELS; i++){
      value |= digitalRead(channels[i]) << i;
  }

  //rBuffer.Produce(random(0,255));  // for simulation purpose only
  rBuffer.Produce(value);
  readInputsMux.unlock();
  
}

//#pragma region Hardware Configuration

void DigitalIO_Config(){

// outputs
  pinMode(BOARD_STATE,OUTPUT);
  

// inputs
  pinMode(CHANNEL0,INPUT_PULLUP);
  pinMode(CHANNEL1,INPUT_PULLUP);
  pinMode(CHANNEL2,INPUT_PULLUP);
  pinMode(CHANNEL3,INPUT_PULLUP);
  pinMode(CHANNEL4,INPUT_PULLUP);
  pinMode(CHANNEL5,INPUT_PULLUP);


  Serial.println("Digital IO configured");
}

void TimerConfig(){
  
  heartBeat_timer = timerBegin(0, 80, true);
  timerAttachInterrupt(heartBeat_timer, &onHeartBeatTimer, true);
  timerAlarmWrite(heartBeat_timer, HALF_SECOND, true);
  timerAlarmEnable(heartBeat_timer);

  sampling_timer = timerBegin(1, 80, true);
  timerAttachInterrupt(sampling_timer, &OnOneMsTimer, true);
  timerAlarmWrite(sampling_timer, ONE_Milli_SECOND, true);
  timerAlarmEnable(sampling_timer);

  Serial.println("Timers Configured");
}

void UartConfig(){
    
    Serial.begin(115200);
    Serial.println("Uart Configured");
}

void SystemConfig(){
  
  // UART Consol Config
  UartConfig();

  // Digital IO Config
  DigitalIO_Config();

  // Timers Config
  TimerConfig();
  
}

void setup(){
  SystemConfig();
  ApplicationConfig(); 
}

void ApplicationConfig(){
  heartBeatTimerLoader = MAX_HEART_BEAT_TIMER_LOAD;
  Serial.println("Application started");
}

void loop() {
  
  delay(100);
  for(int i=0; i< MAX_BUFFER_OUTPUT; i++)
  {
    rBuffer.Consume(bufferOutput[i]);
  }
  Serial.write(bufferOutput,MAX_BUFFER_OUTPUT); // simple way to send data to PC
  }
