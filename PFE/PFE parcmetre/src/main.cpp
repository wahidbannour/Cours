#include <Arduino.h>
#include <HardwareSerial.h>
#include "parcmetre.h"
//#include "PosPrinter.h"
#include "PrinterHardwareSerial.h"
#include "LiquidCristalI2c.h"
#include <mutex>
#include "Button.h"

using namespace std;

hw_timer_t *lcd_timer = NULL;
hw_timer_t *wait_timer = NULL;
mutex lcdMux ;
HardwareSerial printer(2);
HardwareSerial debug(0);
String LcdMessage = "";
int LcdMaxDecalage=0;
volatile int LcdIterator = 0;
int LcdLine =0;
int LcdColomn = 0;
PrinterHardwareSerial serialPrinter(printer); 
//PrinterHardwareSerial serialPrinter(debug); 
PosPrinter posPrinter(serialPrinter);

LiquidCrystal_I2C lcd(0x27,20,4);  // set the LCD address to 0x27 for a 16 chars and 2 line display

String inputString = "";         // a String to hold incoming data
bool stringComplete = false;  // whether the string is complete
volatile float coinValue1 = 0.5;   
volatile float coinValue2 = 1;
volatile float coinValue3 = 2;
volatile float coinValue4 = 0.1;
volatile float coinValue5 = 0.2;


lcdStates lcdState;
monayeurStates monayeurState;
parcmetreStates parcState;

DebouncedInput * inputs[MAX_INPUTS];
bool bouton1=RELEASED;
bool bouton2=RELEASED;
bool bouton3=RELEASED;
bool validation=RELEASED;
bool ch1=RELEASED;
bool ch2=RELEASED;
bool ch3=RELEASED;
int choixTarif = 0;
float tarif =0.0;
float totalMonnaie = 0.0;
volatile bool EndTimer =false;
int lastLcdIterator = 0;
volatile int waitIterator = 0;

void IRAM_ATTR OnLcdUpdate(){
  lcdMux.lock();
  if(LcdIterator == 0)
  {
    LcdIterator = LcdMaxDecalage;
  }
  LcdIterator--;
  lcdMux.unlock();  
}

void IRAM_ATTR OnTimerFinish(){
    if(waitIterator==0)
      waitIterator = 10;
    waitIterator--;
    if(waitIterator==0)
      EndTimer = true;
}

void SerialSetup(){

  debug.begin(115200,SERIAL_8N1,CONSOLE_RX,CONSOLE_TX);
  debug.println("PARKMETER Program started");
  printer.begin(38400, SERIAL_8N1, PRINTER_RX, PRINTER_TX);
  debug.println("UART printer is configured seccessfully");
  
}

void TimerSetup(){
  lcd_timer = timerBegin(0, 80, true);
  timerAttachInterrupt(lcd_timer, &OnLcdUpdate, true);
  timerAlarmWrite(lcd_timer, DEFIL_TIME, true);
  wait_timer = timerBegin(1, 80, true);
  timerAttachInterrupt(wait_timer, &OnTimerFinish, true);
  timerAlarmWrite(wait_timer, HALF_SECOND, true);
}
void DigitalIoSetup(){
  pinMode(BOUTON_1, INPUT_PULLUP);
  pinMode(BOUTON_2, INPUT_PULLUP);
  pinMode(BOUTON_3, INPUT_PULLUP);
  //pinMode(BOUTON_4, INPUT_PULLUP);
  pinMode(BOUTON_VALID, INPUT_PULLUP);
  

  pinMode(coinPin1, INPUT_PULLUP);
  pinMode(coinPin2, INPUT_PULLUP);
  pinMode(coinPin3, INPUT_PULLUP);

  inputs[INPUT_BOUTON_1] = new DebouncedInput(BOUTON_1);
  inputs[INPUT_BOUTON_2] = new DebouncedInput(BOUTON_2);
  inputs[INPUT_BOUTON_3] = new DebouncedInput(BOUTON_3);
  inputs[INPUT_VALID] = new DebouncedInput(BOUTON_VALID);
  inputs[INPUT_COIN_CH1] = new DebouncedInput(coinPin1);
  inputs[INPUT_COIN_CH2] = new DebouncedInput(coinPin2);
  inputs[INPUT_COIN_CH3] = new DebouncedInput(coinPin3);
  
  
}


void SystemSetup(){
  SerialSetup();
  TimerSetup();
  DigitalIoSetup();
}

void LcdPrintAsync(String message,int ligne, int colonne, int maxDecalage){
  timerAlarmDisable(lcd_timer);
  LcdMessage =message;
  LcdMaxDecalage =maxDecalage;
  LcdIterator = 0;
  LcdLine = ligne;
  LcdColomn = colonne;
  lcd.setCursor(colonne,ligne);
  lcd.print(LcdMessage);
  if(maxDecalage > 0)
    lcdState = lcdStates::defilement;
  else
    lcdState = lcdStates::idleLcd;
  timerAlarmEnable(lcd_timer);
}

void Welcome(){
  lcdState = lcdStates::idleLcd;
  lcd.init();                      // initialize the lcd 
  // Print a message to the LCD.
  lcd.backlight();
  lcd.setCursor(0,0);
  lcd.print("PARCMETRE V1.0");
  lcd.setCursor(2,1);
  lcd.print("    SECA  ");
  lcd.setCursor(0,0);
  delay(2000);
 /* lcd.print("PARCMETRE: demo PFE 2023");
  for(int i=30; i>0;i--){
    lcd.scrollDisplayLeft();
    delay(300);
  }*/
  lcd.clear();
  lcd.setCursor(6,1);
  lcd.print("START");
  
  //lcd.noBacklight();
}

void AfficheTarif(){
  lcd.clear();
  lcd.setCursor(10,0);
  lcd.print("Les Tarifs");
  LcdPrintAsync("1H : 0.5DT - 2H: 1DT - 3H : 2DT",1,0,30);
}

void AfficheSelection(int choix){
  lcd.clear();
  lcd.setCursor(1,0);
  String duree;
  switch (choix)
  {
  case 1: 
    duree = "1H";
    break;
  case 2: 
    duree = "2H";
    break;
  case 3: 
    duree = "3H";
    break;
  default:
    break;
  }
  lcd.print("Choix : " + duree + " Appuye sur validation SVP ou faire un autre choix");
  LcdPrintAsync("1H : 0.5DT - 2H: 1DT - 3H : 2DT",1,0,75);
}

void AfficheMontant(float montant){
  lcd.clear();
  lcd.setCursor(0,0);
  lcd.print("Le montant est : " + String(montant) + " DT");
  LcdPrintAsync("Inserez une piece SVP ",1,0,30);
}

void ApplicationSerialDemoSetup()
{
  debug.println("Serial POS Printer Demo started");
  posPrinter.InitPrinter();
}
void ApplicationSetup(){
    lcdState = lcdStates::idleLcd;
    monayeurState = monayeurStates::idleMon;
    parcState = parcmetreStates::initParc;
    posPrinter.InitPrinter();
    debug.println("start program parkmeter");
    //ApplicationSerialDemoSetup();
}

void setup() {
  // put your setup code here, to run once:
  SystemSetup();
  ApplicationSetup();
}

void SerialPosPrinterDemo(){
  static int i=0;

  //if(i > 5) return;
  
  i++;
  debug.println("printing ticket");
  // printer TM-T88III => config : debit 38400, data 8, Stop 1 , parity none flow control : none
  //byte[] bytesToSend = {}
  
  posPrinter.SelectStandardMode();
  posPrinter.SetHorizontalAndVerticalMotion((char)180, (char)180);
  posPrinter.JustifyText(Justification::Center);
  
  String text = "Hello world from ESP32" ;
  posPrinter.Print(text);
            
  
  delay(2000);
  
  if(stringComplete){
    lcd.setCursor(0,0);
    lcd.print("data arrived");
    debug.println(inputString);
    inputString="";
    stringComplete =false;
  }
  
  
}

void PrintTicket(int choix){
  posPrinter.SelectStandardMode();
  posPrinter.SetHorizontalAndVerticalMotion((char)180, (char)180);
  posPrinter.JustifyText(Justification::Center);
  
  String text = "Ticket Parking SECA" ;
  posPrinter.Print(text);
  posPrinter.Print("");
  posPrinter.Print("");
  posPrinter.Print("");
  posPrinter.JustifyText(Justification::Left);
  text = "Durée de Stationnement" ;
  posPrinter.Print(text);
  posPrinter.Print("");
  text = String(choix) + "Heure" ;
  posPrinter.Print(text);
  posPrinter.Print("");
  text = "Montant : " ;
  switch (choix)
  {
  case 1:
    text += String(coinValue1) + " DT";
    break;
  case 2:
    text += String(coinValue2) + " DT";
    break;
  case 3:
    text += String(coinValue3) + " DT";
    break;
  default:
    break;
  }
  posPrinter.Print(text);
  for(int i =0 ;i<20;i++)
    posPrinter.Print("");
  
}


void fsm_Affichage(){
  switch(lcdState){
    case lcdStates::idleLcd : 
      break;
    case lcdStates::defilement:
      if(LcdIterator !=0 && LcdIterator != lastLcdIterator )
      {
        lastLcdIterator = LcdIterator;
        lcd.scrollDisplayLeft();
      }
        
      break;
  } 
}

void GetInputs(){
  for (int i=0 ; i< MAX_INPUTS; i++){

    if(inputs[i]->debouceIndex >= MAX_DEBOUNCE ){
      inputs[i]->debouceIndex = 0;
    }
    inputs[i]->debounces[inputs[i]->debouceIndex] = digitalRead(inputs[i]->gpioNumber);
    inputs[i]->debouceIndex++;  
    bool wstate = inputs[i]->debounces[0];
    bool stable = true;
    for (int j=1 ; j< MAX_DEBOUNCE; j++){
      if(wstate != inputs[i]->debounces[j])  
      {
        stable = false;
        break;
      }           
      wstate = inputs[i]->debounces[j];
    }
    if (stable)
      inputs[i]->state = inputs[i]->debounces[0];
  }
}
void fsm_Parcmetre(){
  switch (parcState)
  {
  
  case parcmetreStates::initParc :
    Welcome();
    parcState = parcmetreStates::idleParc;
    break;
  
  case parcmetreStates::idleParc:
    bouton1=RELEASED;
    bouton2=RELEASED;
    bouton3=RELEASED;
    validation=RELEASED;
    ch1=RELEASED;
    ch2=RELEASED;
    ch3=RELEASED;
    choixTarif = 0;
    tarif =0.0;
    totalMonnaie = 0.0;
    AfficheTarif();
    parcState = parcmetreStates::waitingForChoice;
    break;
  
  case parcmetreStates::waitingForChoice :
    if( inputs[INPUT_BOUTON_1]->state  == PRESSED || 
        inputs[INPUT_BOUTON_2]->state == PRESSED || 
        inputs[INPUT_BOUTON_3]->state == PRESSED )
      {
        bouton1 = inputs[INPUT_BOUTON_1]->state;
        bouton2 = inputs[INPUT_BOUTON_2]->state;
        bouton3 = inputs[INPUT_BOUTON_3]->state;
        if(bouton1 == PRESSED)
          choixTarif = 1;
        if(bouton2 == PRESSED)
          choixTarif = 2;
        if(bouton3 == PRESSED)
          choixTarif = 3;
        AfficheSelection(choixTarif);
        parcState = parcmetreStates::waitingForValidation;
      }
    break;
  
  case parcmetreStates::waitingForValidation :
    if(inputs[INPUT_VALID]->state == PRESSED)
    {
      parcState = parcmetreStates::calculation;
    }
    else 
      if( inputs[INPUT_BOUTON_1]->state  == PRESSED || 
        inputs[INPUT_BOUTON_2]->state == PRESSED || 
        inputs[INPUT_BOUTON_3]->state == PRESSED )
      {
        bouton1 = inputs[INPUT_BOUTON_1]->state;
        bouton2 = inputs[INPUT_BOUTON_2]->state;
        bouton3 = inputs[INPUT_BOUTON_3]->state;
        if(bouton1 == PRESSED)
          choixTarif = 1;
        if(bouton2 == PRESSED)
          choixTarif = 2;
        if(bouton3 == PRESSED)
          choixTarif = 3;
        AfficheSelection(choixTarif);
      }
    break;
  
  case parcmetreStates::calculation :
    switch(choixTarif){
      case 1 : tarif = coinValue1; break;
      case 2 : tarif = coinValue2; break;
      case 3 : tarif = coinValue3; break;
    }
    AfficheMontant(tarif);
    parcState = parcmetreStates::waitingForMoney;
    break;  
  
  case parcmetreStates::waitingForMoney :
    switch(choixTarif){
        case 1 : 
          if(inputs[INPUT_COIN_CH1]->state == PRESSED)
            parcState = parcmetreStates::printing;
          break;
        case 2 : 
          if(inputs[INPUT_COIN_CH2]->state == PRESSED)
            parcState = parcmetreStates::printing;
          break;
        case 3 : 
          if(inputs[INPUT_COIN_CH3]->state == PRESSED)
            parcState = parcmetreStates::printing;
          break;
      }
    break;
  
  case parcmetreStates::printing :
    lcd.clear();
    LcdPrintAsync("Impression du Ticket en cours...",0,0,30);
    PrintTicket(choixTarif);
    EndTimer = false;
    timerAlarmEnable(wait_timer);
    parcState = parcmetreStates::waitForPrinter;
    break;
  
  case parcmetreStates::waitForPrinter:
    if(EndTimer)
    {
      timerAlarmDisable(wait_timer);
      parcState = parcmetreStates::idleParc;
    } 
    break;
  
  default:
    break;
  }
}

void loop() {
  
  static int iteration =0;

  delay(10);
  iteration++;

  GetInputs();
  fsm_Parcmetre();
  fsm_Affichage();

  if(iteration == 50){
    iteration =0;
    debug.print("inputs : ");
    debug.print(inputs[INPUT_BOUTON_1]->state);
    debug.print(" - ");
    debug.print(inputs[INPUT_BOUTON_2]->state);
    debug.print(" - ");
    debug.print(inputs[INPUT_BOUTON_3]->state);
    debug.print(" - ");
    debug.print(inputs[INPUT_VALID]->state);
    debug.print(" - ");
    debug.print(inputs[INPUT_COIN_CH1]->state);
    debug.print(" - ");
    debug.print(inputs[INPUT_COIN_CH2]->state);
    debug.print(" - ");
    debug.println(inputs[INPUT_COIN_CH3]->state);
    //debug.print("fsm LCD : ");
    //debug.println(lcdState);
    
    debug.print("fsm Parcmetre : ");
    debug.println(parcState);
  }
  
}


