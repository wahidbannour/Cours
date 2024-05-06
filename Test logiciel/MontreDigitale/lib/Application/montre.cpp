#include "montre.hpp"
#include "bspMontre.h"

 Montre::Montre(IDigitalIo& io){
    this->io = &io;
 }

/// @brief implémentation de la méthode IsLight()
/// @return 
bool Montre::IsLight(){
    return io->digitalRead(LIGHT_BUTTON);
}


bool Montre::IsMode(){
    return io->digitalRead(MODE_BUTTON);
}

bool Montre::IsStartStop(){
    return io->digitalRead(STARTSTOP_BUTTON);
}

bool Montre::IsSet(){
    return io->digitalRead(SET_BUTTON);
}



void Montre::FsmModeChrono(){

}

void Montre::ActivateLight(){
  io->digitalWrite(LIGHT, HIGH);
}

void Montre::DiactivateLight(){
  io->digitalWrite(LIGHT, LOW);
}

void Montre::StartTimerLight2s(){
    isTimerLightActive= true;
}

void Montre::StopTimerLight2s(){
    isTimerLightActive = false;
}
bool Montre::IsTimerLight2sActive(){
    return isTimerLightActive;
}

bool Montre::IsEndTimerLight2s(){
    return flagTimerLight;
}

void Montre::ArmerTimerMajHeure1s(){
    flagTimerAffichage = false;
}
bool Montre::IsEndTimerMajHeure1s(){
    return flagTimerAffichage;
}






/// @brief implémentation de la machine à états finis de la montre
/// @return 
void  Montre::FsmMontre(){
  // FSM MAJ Heure
    if(IsEndTimerMajHeure1s()){
        heure.majHeure();
        flagAffichage = true;
        ArmerTimerMajHeure1s();
    }
    // FSM Montre
    switch(MontreState){

        case MontreStates::ModeAffichage:
            FsmModeAffichage();
            if( IsMode())
                MontreState = MontreStates::ModeChrono;
        break;
        case MontreStates::ModeChrono:
            FsmModeChrono();
            if( IsMode())
                MontreState = MontreStates::ModeReglage;
        break;
        case MontreStates::ModeReglage:
            FsmModeReglage();
            if( IsMode())
                MontreState = MontreStates::ModeAffichage;
        break;

    }
    // FSM Light
    switch (LightState)
    {
    case LightStates::LightOff :
        if(IsLight()){
            ActivateLight();
            StartTimerLight2s();
            LightState = LightStates::LightOn;
        }
        break;
    case LightStates::LightOn :
        if(IsLight()){
            StartTimerLight2s();
        }
        if(IsEndTimerLight2s()){
            DiactivateLight();
            StopTimerLight2s();
            LightState = LightStates::LightOff;
        }
        break;
    default:
        break;
    }
}


void Montre::FsmModeAffichage(){
    if(flagAffichage){
        afficheur.AfficherSansClignoter(heure.toString());
        flagAffichage = false;
    }
}

void Montre::FsmModeReglage(){
    switch (ReglageState)
    {
    case ModeReglageStates::SecondSetting :
        if(flagAffichage){
            afficheur.AfficherClignoterSeconde(heure.toString());
            flagAffichage = false;
        }
        
        if(IsStartStop()){
            ReglageState = ModeReglageStates::MinuteSetting;
            break;
        }
        if(IsSet()){
            heure.razSecondes();
            break;
        }
        break;
    case ModeReglageStates::MinuteSetting :
        if(flagAffichage){
            afficheur.AfficherClignoterMinute(heure.toString());
            flagAffichage = false;
        }
        
        if(IsStartStop()){
            ReglageState = ModeReglageStates::HourSetting;
            break;
        }
        if(IsSet()){
            heure.incMinutes();
            break;
        }
        break;
    case ModeReglageStates::HourSetting :
        if(flagAffichage){
            afficheur.AfficherClignoterHeure(heure.toString());
            flagAffichage = false;
        }
        
        if(IsStartStop()){
            ReglageState = ModeReglageStates::SecondSetting;
            break;
        }
        if(IsSet()){
            heure.incHeures();
            break;
        }
        break;
    default:
        break;
    }
}