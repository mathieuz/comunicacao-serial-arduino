void setup() {
  Serial.begin(9600);
}

void loop() {
  String str = "FASFDA;true;42300";

  Serial.println("String enviada: " + str + "\n");

  String info1 = "";
  String info2 = "";
  String info3 = "";

  String infos[] = {info1, info2, info3};

  int indexSeparador = -1;
  int variavelInfo = 0;

  for (int i = 0; i < str.length(); i++)
  {
    indexSeparador = indexSeparador + 1;

    String strExtraida = str.substring(indexSeparador, str.indexOf(";", indexSeparador));

    indexSeparador = str.indexOf(";", indexSeparador);

    infos[variavelInfo] = strExtraida;

    variavelInfo = variavelInfo + 1;

  }

  Serial.println("info1: " + infos[0]);
  Serial.println("info2: " + infos[1]);
  Serial.println("info3: " + infos[2]);

  bool run = false;
  while (run == false){}
}