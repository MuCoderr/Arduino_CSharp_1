int led = 8;

void setup() {
  Serial.begin(9600);
  pinMode(led,OUTPUT);
}

void loop() {
  int deger = Serial.read();

  if (deger == '0'){
    digitalWrite(led,LOW);
    }

  if (deger == '1'){
    digitalWrite(led,HIGH);
  }

  delay(50);
}
