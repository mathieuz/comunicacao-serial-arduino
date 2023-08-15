#include <EEPROM.h>
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

    Serial.println("Valor recebido: " + strRecebida + "\n");

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

    //Se o CRC calculado for igual à o valor de CRC enviado, as informações dos valores 
    //não sofreram mudanças ou perdas durante à transmissão. Os valores (strValores) podem ser armazenados na EEPROM.
    if (crcCalculado == strValoresCrc) 
    {
      digitalWrite(ledVerde, HIGH);
      delay(2000);
      digitalWrite(ledVerde, LOW);

      //valoresExtraidosArrayString: vai alocar as substrings extraídas de strValores.
      //Cada substring é um valor. Ao todo, são 4 valores para serem extraídos.
      String valoresExtraidosArrayString[4];

      //indexSeparador: vai recebendo os índices do separador (;) conforme o loop.
      //indiceValor: o contador de índice de valoresExtraidosArrayString.
      int indexSeparador = -1;
      int indiceValor = 0;

      //Loop que percorre strValores, identifica índices do separador e atribui os valores
      //dentro do array de valores extraídos.
      for (int i = 0; i < strValores.length(); i++)
      {
        indexSeparador = indexSeparador + 1; //Inicia o loop com 0.

        //Extrai a substring/valor que antecede um separador dentro da string total.
        String strExtraida = strValores.substring(indexSeparador, strValores.indexOf(";", indexSeparador));

        indexSeparador = strValores.indexOf(";", indexSeparador); //Recebe o índice do próximo separador.

        valoresExtraidosArrayString[indiceValor] = strExtraida; //Atribui o valor no índice atual.

        indiceValor = indiceValor + 1; //Avança para o próximo índice do Array.

        //Se o valor de indexSeparador retornar -1, significa que não foi encontrado
        //mais nenhum separador dentro da string. O loop encerra.
        if (indexSeparador == -1){ break; }

      }

      //Recebe os valores de strValores individualmente, em variáveis separadas.
      String chave = valoresExtraidosArrayString[0];
      String modoOperacao = valoresExtraidosArrayString[1];
      String classe = valoresExtraidosArrayString[2];
      String tempoMsUplink = valoresExtraidosArrayString[3];

      Serial.println("Chave: " + chave);
      Serial.print("Modo de Operação: "); Serial.println(modoOperacao == "0" ? "OTAA" : "ABP");
      Serial.println("Classe: " + classe);
      Serial.println("Tempo em milissegundos do Uplink: " + tempoMsUplink);

      //Limpa todos os endereços da EEPROM.
      for (int i = 0; i < EEPROM.length(); i++)
      {
        EEPROM.write(i, 0);
      }

      //enderecoIndice: determina o próximo endereço na EEPROM a ser preenchido.
      int enderecoIndice = 0;

      //Preenchendo os primeiros endereços com o valor de chave.
      for (int i = 0; i < chave.length(); i++)
      {
        EEPROM.write(enderecoIndice, chave[i]);
        enderecoIndice = enderecoIndice + 1;
      }

      enderecoIndice = enderecoIndice + 1;

      for (int i = 0; i < modoOperacao.length(); i++)
      {
        EEPROM.write(enderecoIndice, modoOperacao[i]);
        enderecoIndice = enderecoIndice + 1;
      }

      enderecoIndice = enderecoIndice + 1;

      for (int i = 0; i < classe.length(); i++)
      {
        EEPROM.write(enderecoIndice, classe[i]);
        enderecoIndice = enderecoIndice + 1;
      }

      enderecoIndice = enderecoIndice + 1;

      for (int i = 0; i < tempoMsUplink.length(); i++)
      {
        EEPROM.write(enderecoIndice, tempoMsUplink[i]);
        enderecoIndice = enderecoIndice + 1;
      }

    } else {
      digitalWrite(ledVermelho, HIGH);
      delay(2000);
      digitalWrite(ledVermelho, LOW);
    }
  }

  bool run = true;
  while (run == false){}
}