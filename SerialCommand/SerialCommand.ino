String hold;
String commands[] = {"ledOn","ledOff"};
int ledPin = 8;
int testPin=7;
int signal,lastSignal;

void runCommand(String command){
 if(command==commands[0]){//ledOn
  digitalWrite(ledPin,HIGH); 
  Serial.println("High");
 }
  if(command==commands[1]){//ledOff
  digitalWrite(ledPin,LOW); 
  digitalWrite(testPin,LOW);
 }
}

void setup()
{  
  pinMode(ledPin,OUTPUT);
  pinMode(testPin,INPUT);
  Serial.begin(57600); 
}

void loop()
{ 

  if(Serial.available()>0){  
    hold = Serial.readStringUntil(32);
    for(int i=0; i<sizeof(commands); i++){
     if(hold==commands[i]){
      runCommand(commands[i]);
     } 
    }
 }
 signal = digitalRead(testPin);
if(signal==HIGH&&lastSignal==LOW) 
   Serial.println("1111111");

if(signal==LOW&&lastSignal==HIGH)
   Serial.println("2222222");
lastSignal=signal;
}

