#include  <LiquidCrystal.h>
 

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);
 
void setup()
{
  Serial.begin(9600);
  lcd.begin(16, 2);
}

  String ch = "\0";


void loop()
{
  if( Serial.available())
  {
    ch = Serial.readString();     
    if(ch != "\0"){
      lcd.clear();   
      lcd.print(ch);
      ch = "\0";
    }
  }
}
