#include <EEPROM.h>

void setup() {
  Serial.begin(9600);
  Serial.setTimeout(10);
}

void loop() {
  for (int i = 0; i < 100; i++)
  {
    Serial.print((char) EEPROM.read(i));
  }

  bool run = false;
  while (run == false){}
}