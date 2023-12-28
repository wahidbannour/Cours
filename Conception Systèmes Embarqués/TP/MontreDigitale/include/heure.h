#include <string>

class Heure{
    private :
    int secondes = 0 ;
    int minutes = 0;
    int heures = 0;

    public:
    void razSecondes();
    void incSecondes();
    void incMinutes();
    void incHeures();
    void majHeure();
    std::string toString();
};