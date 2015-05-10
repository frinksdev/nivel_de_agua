#include <SoftwareSerial.h>
#include <LiquidCrystal.h>
LiquidCrystal lcd(12, 11, 5, 4, 3, 2);
 
const int trigger=10;
const int echo=13;
const float area=.00333;
float distance;
float height;
float liter;
float level;
const float tlevel= .3;
const float maxrange= 0.90;
const float minrange= 0.09;

void setup(){
  Serial.begin(9600);
  pinMode(trigger,OUTPUT);
  pinMode(echo,INPUT);
  lcd.begin(16,2);  
}
 
void loop(){
  //Inicializamos el sensor
  digitalWrite(trigger,LOW);
  delayMicroseconds(5);
// Comenzamos las mediciones
// Enviamos una señal activando la salida trigger durante 10 microsegundos
  digitalWrite(trigger,HIGH);
  delayMicroseconds(10);
  digitalWrite(trigger,LOW);
// Adquirimos los datos y convertimos la medida a metros
 distance=pulseIn(echo,HIGH); // Medimos el ancho del pulso 
                              // (Cuando la lectura del pin sea HIGH medira 
                              // el tiempo que transcurre hasta que sea LOW
 height=(distance*0.0001657);
 level= (tlevel-height);
// Enviamos los datos medidos a traves del puerto serie y al display LCD
  liter= (level*area)*1000;
  Serial.println(liter); 
  delay(1000);
    
    if (liter>=maxrange){
     lcd.setCursor(0,0);
     lcd.print(" Nivel de agua ");
     delay(500);
     lcd.setCursor(0,0);
     lcd.print("   al Maximo   ");
     lcd.setCursor(0,1);
     delay(500);
     lcd.print(liter); lcd.print("  litros  ");
     delay(80);
    }
    if (liter<=minrange){
     lcd.setCursor(0,0);
     lcd.print(" Nivel de agua ");
     delay(500);
     lcd.setCursor(0,0);
     lcd.print("   al minimo   ");
     delay(500);
     lcd.setCursor(0,1);
     lcd.print(liter); lcd.print("  litros  ");
     delay(80);
     }
    else {
     lcd.setCursor(0,0);
     lcd.print(" Nivel de agua ");
     delay(1500);
     lcd.setCursor(0,1);
     lcd.print (liter); lcd.print("  litros  ");
     delay(80);
     }
 

  
}
























































































































































































































































































































































































































































