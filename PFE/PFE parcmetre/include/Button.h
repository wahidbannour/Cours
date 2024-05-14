#define MAX_DEBOUNCE 3

struct DebouncedInput{
    bool state;
    bool debounces[MAX_DEBOUNCE];
    char debouceIndex;
    int gpioNumber;

    DebouncedInput(int wgpioNumber){
        
        for(int i=0; i < MAX_DEBOUNCE; i++)
        {
            debounces[i] = RELEASED;
        }
        state = RELEASED;   
        gpioNumber = wgpioNumber;
        debouceIndex = 0;
    }
};

