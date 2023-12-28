#include <Arduino.h>
#include "montre.h"
#include "bspMontre.h"


// function declarations 
void configSystem();
void configApplication();
void IRAM_ATTR onLightTimer();
void IRAM_ATTR onAfficheTimer();
void IRAM_ATTR onClignotementTimer();
void IRAM_ATTR onTimeoutTimer();
void  Logger();

// global variable and object instanciation
Montre montre = Montre();
hw_timer_t *light_timer = NULL;
hw_timer_t *affichage_timer = NULL;
hw_timer_t *clignote_timer = NULL;
hw_timer_t *timeout_timer = NULL;

portMUX_TYPE lightTimerMux = portMUX_INITIALIZER_UNLOCKED;
portMUX_TYPE affichageTimerMux = portMUX_INITIALIZER_UNLOCKED;
portMUX_TYPE clignoteTimerMux = portMUX_INITIALIZER_UNLOCKED;
portMUX_TYPE timeoutTimerMux = portMUX_INITIALIZER_UNLOCKED;

unsigned long currentTime=0;
// setup arduino framework
void setup() {
  // put your setup code here, to run once:
  configSystem();
  configApplication();
  // pour avoir un écho de débogage sur la console du PC
  Serial.begin(115200);
  Serial.println("programme Montre 2023");
  currentTime = millis();
}

// loop arduino framework
void loop() {
  
  montre.FsmMontre();
  montre.afficheur.FsmAfficheur();

  if(montre.IsTimerLight2sActive())
    timerAlarmEnable(light_timer);
  else
    timerAlarmDisable(light_timer);
  
  if(montre.afficheur.IsTimerClignotementActive())
    timerAlarmEnable(clignote_timer);
  else
    timerAlarmDisable(clignote_timer);
  
  if((millis()- currentTime) >= 900){
    //Logger();
    currentTime = millis();
  }

  sleep(1);
}


//method implementation

void configSystem(){
  // Timers
  light_timer = timerBegin(0, 80, true);
  timerAttachInterrupt(light_timer, &onLightTimer, true);
  timerAlarmWrite(light_timer, TWO_SECOND, false);

  affichage_timer = timerBegin(1, 80, true);
  timerAttachInterrupt(affichage_timer, &onAfficheTimer, true);
  timerAlarmWrite(affichage_timer, ONE_SECOND, true);
  timerAlarmEnable(affichage_timer);

  clignote_timer = timerBegin(2, 80, true);
  timerAttachInterrupt(clignote_timer, &onClignotementTimer, true);
  timerAlarmWrite(clignote_timer, QUARTER_SECOND, false);
  
  timeout_timer = timerBegin(3, 80, true);
  timerAttachInterrupt(timeout_timer, &onTimeoutTimer, true);
  timerAlarmWrite(timeout_timer, TWO_MINUTE, false);

  // Digital IO

  pinMode(SET_BUTTON,INPUT_PULLDOWN);
  pinMode(STARTSTOP_BUTTON,INPUT_PULLDOWN);
  pinMode(LIGHT_BUTTON,INPUT_PULLDOWN);
  pinMode(MODE_BUTTON,INPUT_PULLDOWN);

  pinMode(LIGHT,OUTPUT);

}

void configApplication(){
  montre.MontreState = MontreStates::ModeAffichage;
  montre.LightState = LightStates::LightOff;
  montre.ChronoState = ModeChronoStates::Stopped;
  montre.ReglageState = ModeReglageStates::SecondSetting;
  montre.afficheur.Init();
}


void IRAM_ATTR onLightTimer(){
 portENTER_CRITICAL(&lightTimerMux);
  montre.flagTimerLight = true;
  portEXIT_CRITICAL(&lightTimerMux); 
}

void IRAM_ATTR onAfficheTimer(){
  portENTER_CRITICAL(&affichageTimerMux);
  montre.flagTimerAffichage = true;
  portEXIT_CRITICAL(&affichageTimerMux);
}

void IRAM_ATTR onClignotementTimer(){
  portENTER_CRITICAL(&clignoteTimerMux);
  montre.afficheur.flagTimerAfficheur = true;
  portEXIT_CRITICAL(&clignoteTimerMux);
}

void IRAM_ATTR onTimeoutTimer(){
  portENTER_CRITICAL(&timeoutTimerMux);
  //montre.flagTimerAffichage = true;
  portEXIT_CRITICAL(&timeoutTimerMux);
}

void Logger(){
  Serial.print("Montre State: "); Serial.println(montre.MontreState);
  Serial.print("Reglage State: "); Serial.println(montre.ReglageState);
  Serial.print("Light State: "); Serial.println(montre.LightState);
  Serial.print("Afficheur State: "); Serial.println(montre.afficheur.afficheurState);
 }