#include <string>
#include <LiquidCrystal_I2C.h>

class Afficheur{
    private:
        LiquidCrystal_I2C lcd=LiquidCrystal_I2C(0x27, 16, 2); 
        enum AfficheurStates{
            Stable,
            ClignoteOn,
            ClignoteOff
        };
        
        bool isClignotement =false;
        std::string affichageAvecClignotement;
        std::string affichageSansClignotement;
        bool isTimerAfficheurActive=false;
        void Afficher(std::string heure);
    public:
        AfficheurStates afficheurState = AfficheurStates::Stable;
        volatile bool flagTimerAfficheur =false;

        void Init();
        void AfficherSansClignoter(std::string heure);
        void AfficherClignoterHeure(std::string heure);
        void AfficherClignoterMinute(std::string heure);
        void AfficherClignoterSeconde(std::string heure);
        void FsmAfficheur();
        void StartTimerClignotement();
        void StopTimerClignotement();
        bool IsEndTimerClignotement();
        bool IsTimerClignotementActive();
};