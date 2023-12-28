#include "heure.h"

 void Heure::razSecondes(){
    secondes = 0;
 }

void Heure::incSecondes(){
    secondes++;
    if(secondes > 59)
        secondes=0;
 }

 void Heure::incMinutes(){
    minutes++;
    if(minutes > 59)
        minutes=0;
 }
 
 void Heure::incHeures(){
    heures++;
    if(heures > 23)
    heures = 0;
 }

 std::string Heure::toString(){

   std::string heureComplet;
   auto data = std::to_string(heures);
   if(data.length()==1)
      heureComplet.append("0").append(data).append(":");
   else
      heureComplet.append(data).append(":");
   
   data = std::to_string(minutes);
   if(data.length()==1)
      heureComplet.append("0").append(data).append(":");
   else
      heureComplet.append(data).append(":");
   
   data = std::to_string(secondes);
   if(data.length()==1)
      heureComplet.append("0").append(data);
   else
      heureComplet.append(data);
    return heureComplet;
 }

 void Heure::majHeure(){
    incSecondes();
    if (secondes == 0){
        incMinutes();
        if(minutes==0)
            incHeures();
    }      
 }
