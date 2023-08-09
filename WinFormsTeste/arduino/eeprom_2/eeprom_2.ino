#include <EEPROM.h>
#include <AceCRC.h>

using namespace ace_crc::crc16modbus_bit;

const byte ledVerde = 2;
const byte ledVermelho = 4;

//Variáveis que receberão os valores extraídos da string recebida pelo readString().
String strConcat = ""; //APPKEY, APPSKEY, NWKSKEY
String strConcatCrc = ""; //CRC da String acima
String modoOperacao = ""; 
String classe = ""; //A, B ou C
String tempoMsUplink = ""; //Tempo em milissegundos do Uplink

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

  while (Serial.available() > 0)
  {
    String strRecebido = Serial.readString(); //Recebe a string enviada.

    Serial.println("String recebida pelo serial: " + strRecebido + "\n");

    //Array que armazenará separadamente os valores extraídos da string enviada.
    String arrayValoresString[5];

    //indexSeparador: recebe o índice inicial de -1. No laço de repetição, vai recebendo o valor do próximo índice separador.
    //indexValorString: o contador de índice que pula para a próxima variável do array à cada iteração.
    int indexSeparador = -1;
    int indexValorString = 0;

    //Laço que percorre a string, identifica o índice separador e os valores identificados na substring e atribui nas variáveis
    //do array de strings.
    for (int i = 0; i < strRecebido.length(); i++)
    {
      indexSeparador = indexSeparador + 1;  //Inicia incrementando o valor de índice do separador atual + 1. No ínicio, 0.

      String strExtraida = strRecebido.substring(indexSeparador, strRecebido.indexOf(";", indexSeparador)); //Recebe a substring do índice separador até o índice do ';' mais próximo dentro da string.

      indexSeparador = strRecebido.indexOf(";", indexSeparador); //indexSeparador recebe o índice do próximo ; dentro da string total.

      arrayValoresString[indexValorString] = strExtraida; //Atribui o valor da string extraída para uma variável dentro do vetor.

      indexValorString = indexValorString + 1; //Avança para a próxima variável que vai receber a próxima substring.

      //Se o índice de separador não encontrar mais nenhuma ocorrência de ';' dentro da string, retorna '-1' e encerra o loop.
      if (indexSeparador == -1){ break; }
    }

    String strConcat = arrayValoresString[0];
    String strConcatCrc = arrayValoresString[1];
    String modoOperacao = arrayValoresString[2]; 
    String classe = arrayValoresString[3];
    String tempoMsUplink = arrayValoresString[4];

    Serial.println("Valores extraídos:");
    Serial.println(arrayValoresString[0]);
    Serial.println(arrayValoresString[1]);
    Serial.println(arrayValoresString[2]);
    Serial.println(arrayValoresString[3]);
    Serial.println(arrayValoresString[4]);

    /*
    Serial.println("String recebida: " + strRecebido);
    Serial.println("Valor validado: " + valorRecebido);
    Serial.println("CRC: " + valorCrcRecebido);
    */

    //Faz o cálculo do CRC da informação recebida.
    char strConcatCharArray[strConcat.length()]; //Inicializando array de caracteres.
    for (int i = 0; i <= strConcat.length(); i++)
    {
      strConcatCharArray[i] = strConcat[i];
    }
    
    size_t comprimentoValor = sizeof(strConcatCharArray);

    crc_t crc = crc_init();
    crc = crc_update(crc, strConcatCharArray, comprimentoValor);
    crc = crc_finalize(crc);

    String crcCalculado = String(crc);

    //Serial.println(crcCalculado);

    /*
    Serial.print("Igual? ");
    Serial.println(crcCalculado + "\n" == valorCrcRecebido);
    */

    //Verifica se os dois CRCs (recebido e calculado) são iguais. Se sim, os valores podem ser guardados na EEPROM.
    if (crcCalculado == strConcatCrc)
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

      /*
      for (int i = 0; i < valorRecebido.length(); i++)
      {
        EEPROM.write(i, valorRecebido[i]);
      }
      */

    } else {
      digitalWrite(ledVermelho, HIGH);
      delay(2000);
      digitalWrite(ledVermelho, LOW);
      delay(2000);
    }

  }
}