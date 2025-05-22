volatile byte hopperPulseCount = 0; // Counter for coins ejected
byte coinHopperValue = 0; // Number of pulses required to dispense each coin type

//************ Pins Used *******************
volatile int coinPulseCount = 0;

const int hopperPin = 2; // Optical count input
const int coinAcceptorPin = 3; // Optical count input
const int relayPin = 4; // Output relay

int hopperPinState;

void setup() 
{
  Serial.begin(9600);
  //**** Pin Modes *************
  pinMode(coinAcceptorPin, INPUT_PULLUP); 
  pinMode(hopperPin, INPUT_PULLUP); // Hopper optical count is an input
  pinMode(relayPin, OUTPUT); // Relay pin output
  digitalWrite(relayPin, HIGH); // Turn off relay - active HIGH
  attachInterrupt(digitalPinToInterrupt(coinAcceptorPin), coinInserted, RISING);   
  coinPulseCount = 0; 
  hopperPinState = digitalRead(hopperPin);
}

void coinInserted() 
{ 
  coinPulseCount++; 
  Serial.println(coinPulseCount);      
}

void loop() 
{
  while(Serial.available() == 0) {}
  long x = Serial.parseInt();
  Serial.println(x); 
  coinHopperValue = x;
  if (coinHopperValue >= 0) dispense(); 
}

void hopper() // Function called when coins are being dispensed from the hopper
{
  if (hopperPinState != digitalRead(hopperPin)) {
    if (hopperPinState == HIGH) {
      hopperPinState = LOW;
    } else {
      hopperPinState = HIGH;
      hopperPulseCount++;
      Serial.println(hopperPulseCount);
    }
    delay(50);
  }
}

void dispense()
{ 
  hopperPinState = digitalRead(hopperPin);
  digitalWrite(relayPin, LOW); // Turn on relay - active LOW
  delay(50); 
  hopperPulseCount = 0;
  
  while (hopperPulseCount < coinHopperValue)
  {
    hopper();
  }
  
  delay(50); // Wait to ensure the coin has enough momentum to leave hopper but not long enough for another coin to dispense
  digitalWrite(relayPin, HIGH); // Turn off relay - active HIGH
  
  delay(180);
  coinPulseCount = 0; // Reset coin acceptor pulse count to avoid errors
}
