#include <AceCRC.h>

using namespace ace_crc::crc16modbus_bit;

const byte ledVerde = 2;
const byte ledVermelho = 4;

void setup() {
  Serial.begin(9600);
  Serial.setTimeout(10);

  pinMode(ledVerde, OUTPUT);
  pinMode(ledVermelho, OUTPUT);
}

void loop() {

  while (Serial.available() > 0)
  {
    //String e CRC recebido da porta serial.
    String strRecebida = Serial.readString();

    //Recebe a substring contendo apenas os valores.
    String strValores = strRecebida.substring(0, strRecebida.lastIndexOf(";")); 

    //Recebe a subsstring do CRC dos valores.
    String strValoresCrc = strRecebida.substring(strRecebida.lastIndexOf(";") + 1, strRecebida.length());
    
    //Criando e atribuindo um array de char dos valores recebidos (strValores) para cálculo de CRC.
    char strValoresCharArray[strValores.length()];
    for (int i = 0; i < strValores.length(); i++)
    {
      strValoresCharArray[i] = strValores[i];
    }

    //Calculando o CRC dos valores à partir do array de caracteres da string com os valores (strValores)
    crc_t crc = crc_calculate(strValoresCharArray, sizeof(strValoresCharArray));
    String crcCalculado = String(crc);

    Serial.println(crcCalculado);

    //Se o CRC calculado for igual à o valor de CRC enviado, as informações dos valores 
    //não sofreram mudanças ou perdas durante à transmissão. Os valores (strValores) podem ser armazenados na EEPROM.
    if (crcCalculado == strValoresCrc) 
    {
      digitalWrite(ledVerde, HIGH);
      delay(2000);
      digitalWrite(ledVerde, LOW);

    } else {
      digitalWrite(ledVermelho, HIGH);
      delay(2000);
      digitalWrite(ledVermelho, LOW);

    }
  }

  bool run = true;
  while (run == false){}
}