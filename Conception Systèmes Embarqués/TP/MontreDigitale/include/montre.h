#include "afficheur.h"
#include "heure.h"
#include "chrono.h"

enum MontreStates{

    ModeAffichage,
    ModeChrono,
    ModeReglage,
};

enum LightStates{
    LightOn,
    LightOff,
};

enum ModeChronoStates{
    Started,
    Stopped,
};

enum ModeReglageStates{
    SecondSetting,
    MinuteSetting,
    HourSetting
};

class Montre{
    private:
    
    bool isTimerLightActive = false;
    bool flagAffichage = false;
    public:

    MontreStates MontreState ;
    LightStates LightState;
    ModeChronoStates ChronoState;
    ModeReglageStates ReglageState;

    Afficheur afficheur;
    Heure heure;
    Chrono chrono;

    volatile bool flagTimerLight =false;
    volatile bool flagTimerAffichage =false;

    bool IsMode();
    bool IsLight();
    bool IsStartStop();
    bool IsSet();

    void FsmMontre();
    void FsmModeChrono();
    void FsmModeLight();
    void FsmModeReglage();
    void FsmModeAffichage();
    
    void ActivateLight();
    void DiactivateLight();
    
    void StartTimerLight2s();
    void StopTimerLight2s();
    bool IsTimerLight2sActive();
    bool IsEndTimerLight2s();
    
    void ArmerTimerMajHeure1s();
    bool IsEndTimerMajHeure1s();
};

