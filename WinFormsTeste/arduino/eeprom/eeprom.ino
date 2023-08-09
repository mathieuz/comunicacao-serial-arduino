#include <EEPROM.h>
#include <AceCRC.h>

using namespace ace_crc::crc16modbus_bit;

const byte ledVerde = 2;
const byte ledVermelho = 4;

void setup()
{
  Serial.begin(9600);
  Serial.setTimeout(10);

  pinMode(ledVerde, OUTPUT);
  pinMode(ledVermelho, OUTPUT);
}

void loop()
{
  ///

  bool run = true;
  while (run == false)
  {
    digitalWrite(ledVerde, LOW);
  }

  while (Serial.available() > 0)
  {
    String strRecebido = Serial.readString();

    int indexSeparador = strRecebido.indexOf(";", 0);

    String valorRecebido = strRecebido.substring(0, indexSeparador);
    String valorCrcRecebido = strRecebido.substring(indexSeparador + 1, strRecebido.length());

    Serial.println("String recebida: " + strRecebido);
    Serial.println("Valor validado: " + valorRecebido);
    Serial.println("CRC: " + valorCrcRecebido);

    //Faz o cálculo do CRC da informação recebida.
    char valorRecebidoCharArray[valorRecebido.length()]; //Inicializando array de caracteres.
    for (int i = 0; i <= valorRecebido.length(); i++)
    {
      valorRecebidoCharArray[i] = valorRecebido[i];
    }
    
    size_t comprimentoValor = sizeof(valorRecebidoCharArray);

    crc_t crc = crc_init();
    crc = crc_update(crc, valorRecebidoCharArray, comprimentoValor);
    crc = crc_finalize(crc);

    String crcCalculado = String(crc);

    Serial.println(crcCalculado);

    /*
    Serial.print("Igual? ");
    Serial.println(crcCalculado + "\n" == valorCrcRecebido);
    */

    //Verifica se os dois CRCs (recebido e calculado) são iguais. Se sim, os valores podem ser guardados na EEPROM.
    if (crcCalculado == valorCrcRecebido)
    {
      //Limpa todos os endereços da EEPROM.
      for (int i = 0; i < EEPROM.length(); i++)
      {
        EEPROM.write(i, 0);
      }

      //Acende o led verde 3 vezes, indicando que as informações foram validadas.
      for (int i = 0; i < 3; i++)
      {
        digitalWrite(ledVerde, HIGH);
        delay(300);
        digitalWrite(ledVerde, LOW);
        delay(300);
      }

      for (int i = 0; i < valorRecebido.length(); i++)
      {
        EEPROM.write(i, valorRecebido[i]);
      }

    } else {
      digitalWrite(ledVermelho, HIGH);
      delay(2000);
      digitalWrite(ledVermelho, LOW);
      delay(2000);
    }

  }
}