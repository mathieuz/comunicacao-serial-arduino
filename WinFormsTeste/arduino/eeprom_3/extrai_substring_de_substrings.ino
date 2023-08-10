//Extraíndo valores à partir da substring de uma string.
//As substrings, que são os valores armazenados dentro das variáveis que estão dentro 
//de uma array estão em uma string total, os valores são extraídos, armazenados e lidos pela referência
//de índice dos separadores ';'.

void setup() {
  Serial.begin(9600);
}

void loop() {
  String str = "FASFDA;true;42300;aaaa;bbb"; //Formato de string que possui os valores separados por ;
  str = "teste;0;valor123;abc;def";

  Serial.println("String enviada: " + str + "\n"); //Printando a string completa.

  //Variáveis que vão receber a substring correspondente ao valor da string completa.
  String info1 = "";
  String info2 = "";
  String info3 = "";
  String info4 = "";
  String info5 = "";

  //Array de strings com as variáveis anteriores. Vai permitir iterar sobre cada variável e atribuir um valor extraído
  //da string completa.
  String infos[] = {info1, info2, info3, info4, info5};

  //indexSeparador: recebe o índice inicial de -1. No laço de repetição, vai recebendo o valor do próximo índice separador.
  //variavelInfo: o contador de índice que pula para a próxima variável do array à cada iteração.
  int indexSeparador = -1;
  int variavelInfo = 0;

  //Laço que percorre a string, identifica o índice separador e os valores identificados na substring e atribui nas variáveis
  //do array de strings.
  for (int i = 0; i < str.length(); i++)
  {
    indexSeparador = indexSeparador + 1;  //Inicia incrementando o valor de índice do separador atual + 1. No ínicio, 0.

    String strExtraida = str.substring(indexSeparador, str.indexOf(";", indexSeparador)); //Recebe a substring do índice separador até o índice do ';' mais próximo dentro da string.

    indexSeparador = str.indexOf(";", indexSeparador); //indexSeparador recebe o índice do próximo ; dentro da string total.

    infos[variavelInfo] = strExtraida; //Atribui o valor da string extraída para uma variável dentro do vetor.

    variavelInfo = variavelInfo + 1; //Avança para a próxima variável que vai receber a próxima substring.

    //Se o índice de separador não encontrar mais nenhuma ocorrência de ';' dentro da string, retorna '-1' e encerra o loop.
    if (indexSeparador == -1){ break; }
  }

  Serial.println("Valores extraídos e armazenados nos vetores: ");
  Serial.println("info1: " + infos[0]);
  Serial.println("info2: " + infos[1]);
  Serial.println("info3: " + infos[2]);
  Serial.println("info4: " + infos[3]);
  Serial.println("info5: " + infos[4]);

  bool run = true;
  while (run == false){}
}