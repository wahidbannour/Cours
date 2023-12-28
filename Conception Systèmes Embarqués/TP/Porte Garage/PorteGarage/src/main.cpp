#include <Arduino.h>
#include "BspGarage.h"

enum GarageStates{
    Init = 1,
    PorteOuverte,
    PorteFerme,
    PorteEncoursDouverture,
    PorteEncoursDeFermeture,
    ArretEnCours,
};

GarageStates state;
char SurBouton;
char SurPorteFerme;
char SurProteOuverte;
char moteurS1;
char moteurS2;
volatile char FinTempoDescendant;
volatile char FinTempoMontant;

hw_timer_t *moteur_timer = NULL;



inline void FermerPorte();
inline void OuvrirPorte();
inline void ArreterPorte();

void LireEntrees();
void RafraichirSorties();

void ConfigureHardware();
void ConfigureTimers();
void ConfigureGpio();
void ConfigureApplication();
void FsmGarage();
void ArmerTemporisation();

void IRAM_ATTR onTwoSecond(){
    FinTempoDescendant =true;
    FinTempoMontant = true;
    
}


void setup(){
    ConfigureHardware();
    ConfigureApplication();
}


void loop(){
    LireEntrees();
    FsmGarage();
    RafraichirSorties();
    delay(100);
}


void ConfigureHardware(){
    ConfigureGpio();
    ConfigureTimers();
}

void ConfigureGpio(){

     pinMode(CapteurHaut,INPUT_PULLDOWN);
     pinMode(CapteurBas,INPUT_PULLDOWN);
     pinMode(Bouton,INPUT_PULLDOWN);

     pinMode(MoteurS1,OUTPUT);
     pinMode(MoteurS2,OUTPUT);
}

void ConfigureTimers(){
  
  moteur_timer = timerBegin(0, 80, true);
  timerAttachInterrupt(moteur_timer, &onTwoSecond, true);
  
}



void ConfigureApplication(){
    state = GarageStates::Init;
    SurBouton =false;
    SurPorteFerme=false;
     SurProteOuverte=false;
     moteurS1=false;
     moteurS2=false;
     FinTempoDescendant=false;
     FinTempoMontant=false;
}


void ArmerTemporisation(){
    timerAlarmWrite(moteur_timer, TWO_SECOND, false);
    timerAlarmEnable(moteur_timer);
}

void LireEntrees(){

    SurProteOuverte =  digitalRead(CapteurHaut);
    SurPorteFerme =  digitalRead(CapteurBas);
    SurBouton =  digitalRead(Bouton);
}

void RafraichirSorties(){

    digitalWrite(MoteurS1, moteurS1);
    digitalWrite(MoteurS2, moteurS2);
}


void FsmGarage(){
    switch (state)
    {
    case GarageStates::Init :
        if(SurPorteFerme){
            state = GarageStates::PorteFerme;
            break;
        }
        if(SurProteOuverte){
            state = GarageStates::PorteOuverte;
            break;
        }
        if(!SurProteOuverte && !SurPorteFerme){
            state = GarageStates::PorteEncoursDouverture;
            //OuvrirPorte();
            break;
        }
        break;
    case GarageStates::PorteOuverte :
        /* code */
        break;
    case GarageStates::PorteFerme :
    /* code */
        break;
    case GarageStates::PorteEncoursDouverture :
    /* code */
        break;
    case GarageStates::PorteEncoursDeFermeture :
    /* code */
        break;
    case GarageStates::ArretEnCours :
        break;
    default:
        break;
    }
}