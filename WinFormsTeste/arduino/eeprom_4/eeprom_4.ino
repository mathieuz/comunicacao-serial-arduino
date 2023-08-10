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
    String str = Serial.readString();

    Serial.println("String enviada: " + str + "\n"); //Printando a string completa.

    //Array de strings com as variáveis anteriores. Vai permitir iterar sobre cada variável e atribuir um valor extraído
    //da string completa.
    String valoresExtraidosArray[5];

    //indexSeparador: recebe o índice inicial de -1. No laço de repetição, vai recebendo o valor do próximo índice separador.
    //variavelInfo: o contador de índice que pula para a próxima variável do array à cada iteração.
    int indexSeparador = -1;
    int indiceValor = 0;

    //Laço que percorre a string, identifica o índice separador e os valores identificados na substring e atribui nas variáveis
    //do array de strings.
    for (int i = 0; i < str.length(); i++)
    {
      indexSeparador = indexSeparador + 1;  //Inicia incrementando o valor de índice do separador atual + 1. No ínicio, 0.

      String strExtraida = str.substring(indexSeparador, str.indexOf(";", indexSeparador)); //Recebe a substring do índice separador até o índice do ';' mais próximo dentro da string.

      indexSeparador = str.indexOf(";", indexSeparador); //indexSeparador recebe o índice do próximo ; dentro da string total.

      valoresExtraidosArray[indiceValor] = strExtraida; //Atribui o valor da string extraída para uma variável dentro do vetor.

      indiceValor = indiceValor + 1; //Avança para a próxima variável que vai receber a próxima substring.

      //Se o índice de separador não encontrar mais nenhuma ocorrência de ';' dentro da string, retorna '-1' e encerra o loop.
      if (indexSeparador == -1){ break; }
    }

    Serial.println("Valores extraídos e armazenados nos vetores: ");
    Serial.println("info1: " + valoresExtraidosArray[0]);
    Serial.println("info2: " + valoresExtraidosArray[1]);
    Serial.println("info3: " + valoresExtraidosArray[2]);
    Serial.println("info4: " + valoresExtraidosArray[3]);
    Serial.println("info5: " + valoresExtraidosArray[4]);

    String strConcat = valoresExtraidosArray[0];
    String strConcatCrc = valoresExtraidosArray[1];

    char strConcatCharArray[strConcat.length()];
    for (int i = 0; i < strConcat.length(); i++)
    {
      strConcatCharArray[i] = strConcat[i];
    }

    crc_t crc = crc_calculate(strConcatCharArray, sizeof(strConcatCharArray));
    String crcCalculado = String(crc);

    Serial.print("CRC Recebido: ");
    Serial.println(strConcatCrc);

    Serial.print("CRC Calculado: ");
    Serial.println(crcCalculado);

    if (crcCalculado == strConcatCrc)
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