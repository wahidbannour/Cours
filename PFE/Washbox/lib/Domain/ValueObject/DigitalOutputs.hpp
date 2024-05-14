#ifndef DIGITAL_OUTPUTS
#define DIGITAL_OUTPUTS


/// @brief structure utilisé par le business pour 
/// manipuler les sorties abstraites du washbox
struct Outputs{
    unsigned char Led;
};

/// @brief structure pour définir une abstraction de
/// commande de la Led.
struct LedLogicCommand{
    bool LedOn;
    bool LedOff;
};

#endif
