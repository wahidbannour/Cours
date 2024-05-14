
#include <Services/DigitalIo/IDigitalIo.hpp>

class DigitalIoArduino : public IDigitalIo{
    
    public:
    
    //-RQ1 : il faut faire attention de ne pas utiliser les mêmes nom de fonction
    // qui sont utilisé par le framwork Arduino. ici on a modifié digitalRead -> DigitalRead
    
    //-RQ2 :  il ne faut pas oublier d'ajouter override à la fin de la fonction pour 
    //dire qu'elle remplace la fonction abstraite

    virtual unsigned char DigitalRead(unsigned char address) override ; 
    virtual void DigitalWrite(unsigned char value, unsigned char address) override ;
    
};