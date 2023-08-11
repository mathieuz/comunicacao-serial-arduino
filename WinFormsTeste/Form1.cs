using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;  //Para comunicação de portas seriais.
using System.Windows.Forms;
using System.IO;
using NullFX.CRC; //Cálculo de CRC das informações enviadas.

namespace WinFormsTeste
{
    public partial class Form1 : Form
    {

        //String que sinaliza quebras de linha em textos.
        string newLine = Environment.NewLine;

        //Instanciando objeto de acesso às portas COMs.
        SerialPort _serialPort = new SerialPort();

        //Array de textboxes
        List<TextBox> listTextbox = new List<TextBox>();

        public Form1()
        {
            //Injcializando elementos na tela.

            InitializeComponent();

            //Adiciona números possíveis de portas COMs selecionáveis dentro da Combobox.
            for (int i = 1; i <= 50; i++){
                comboBoxCOM.Items.Add("COM" + i);
            }

            comboBoxCOM.SelectedIndex = 0; //Seleciona o primeiro do índice de itens da combobox.

            //Inicializando lista de textboxes com os três textboxes padrões.
            listTextbox.Add(txt1);
            listTextbox.Add(txt2);
            listTextbox.Add(txt3);


            //Inicializando comboboxes 'Modo de Operação' e 'Classe'.
            comboBoxModoOperacao.Items.Add("OTAA");
            comboBoxModoOperacao.Items.Add("ABP");
            comboBoxModoOperacao.SelectedIndex = 0;

            comboBoxClasse.Items.Add("A");
            comboBoxClasse.Items.Add("B");
            comboBoxClasse.Items.Add("C");
            comboBoxClasse.SelectedIndex = 0;

        }

        private void btConectar_Click(object sender, EventArgs e)
        {
            string portSelecionado = comboBoxCOM.SelectedItem.ToString();

            if (btConectar.Text == "Conectar")
            {
                _serialPort.PortName = portSelecionado;

                //Verifica se a porta está disponível. Se sim, tenta conexão.
                if (_serialPort.IsOpen == false)
                {
                    try
                    {
                        //Tenta conectar na porta selecionada.
                        _serialPort.Open();

                        comboBoxCOM.Enabled = false;

                        groupBox_Enviar.Enabled = true;
                        salvarComoToolStripMenuItem.Enabled = true;
                        abrirToolStripMenuItem.Enabled = true;

                        btConectar.Text = "Desconectar";

                        consoleSaida.AppendText($"[!] Conectado na porta {portSelecionado}." + newLine + newLine);

                    }
                    catch (Exception erro)
                    {
                        consoleSaida.AppendText($"[Erro] Não foi possível se conectar: {erro.Message}" + newLine + newLine);
                    }

                }

            }
            else if (btConectar.Text == "Desconectar")
            {
                //Desconecta da porta.
                _serialPort.Close();

                //Desabilitando/habilitand interações de elementos e limpando campos quando desconectado.
                comboBoxCOM.Enabled = true;

                groupBox_Enviar.Enabled = false;
                salvarComoToolStripMenuItem.Enabled = false;
                abrirToolStripMenuItem.Enabled = false;

                foreach (TextBox tb in listTextbox) { tb.Clear(); }

                btConectar.Text = "Conectar";

                consoleSaida.AppendText($"[!] Desconectado da porta {portSelecionado}." + newLine + newLine);

            }

        }

        //Evento de clique em enviar: os valores definidos nas textboxes e comboboxes são concatenados numa
        //string só, e seu valor de CRC é calculado em seguida. Os valores, string concatenada e seu CRC, é
        //enviado para o arduino.
        private void btEnviar_Click(object sender, EventArgs e)
        {
            //Capturando os valores definidos nos inputs.
            String chave = txt1.Text + txt2.Text + txt3.Text;
            String modoOperacao = comboBoxModoOperacao.SelectedIndex.ToString();
            String classe = comboBoxClasse.SelectedItem.ToString();
            String tempoMsUplink = upDownUplink.Value.ToString();

            //Somando os limites de caracteres dos textboxes referentes à chave.
            int totalMaxLength = txt1.MaxLength + txt2.MaxLength + txt3.MaxLength;

            //Se o comprimento de chave é igual à soma dos três textboxes, o valor poderá ser escrito na porta do serial.
            if (chave.Length == totalMaxLength)
            {
                //Concatenando as configurações definidas em uma string só.
                string strConcat = $"{chave};{modoOperacao};{classe};{tempoMsUplink}";

                //Calculando CRC da string concatenada. A string deve ser convertida em um Array de bytes antes.
                byte[] strConcatBytes = Encoding.UTF8.GetBytes(strConcat);
                string strConcatCrc = Crc16.ComputeChecksum(Crc16Algorithm.Modbus, strConcatBytes).ToString(); //Recebe o CRC referente à string.

                _serialPort.Write(strConcat + ";" + strConcatCrc);   //Escreve a string concatenada com um valor separador (;), que
                                                                     //está concatenada ao valor gerado pelo CRC na porta serial.

                //Exibe os valores enviados no console de saída.
                consoleSaida.AppendText("[!] Enviado: " + strConcat + newLine);
                consoleSaida.AppendText("CRC: " + strConcatCrc + newLine + newLine);
                consoleSaida.AppendText("Valor escrito na porta: " + strConcat + ";" + strConcatCrc + newLine + newLine);


            } else
            {
                consoleSaida.AppendText($"[Erro] Os valores dos campos preenchidos não somam {totalMaxLength} caracteres. Preencha-os e tente novamente." + newLine + newLine);

            }
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int totalMaxLength = txt1.MaxLength + txt2.MaxLength + txt3.MaxLength;

            if (txt1.Text.Length + txt2.Text.Length + txt3.Text.Length == totalMaxLength)
            {
                SaveFileDialog salvaArquivo = new SaveFileDialog();
                salvaArquivo.FileName = "*.txt";
                salvaArquivo.RestoreDirectory = true;
                salvaArquivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                salvaArquivo.DefaultExt = "txt";

                if (salvaArquivo.ShowDialog() == DialogResult.OK)
                {

                    File.WriteAllText(salvaArquivo.FileName, $"{txt1.Text}\n" +
                                                             $"{txt2.Text}\n" +
                                                             $"{txt3.Text}");

                    consoleSaida.AppendText($"[!] O arquivo foi salvo em {salvaArquivo.FileName}" + newLine + newLine);
                }

            } else
            {
                consoleSaida.AppendText($"[Erro] Impossível salvar: os valores dos campos preenchidos não somam {totalMaxLength} caracteres. Preencha-os e tente novamente." + newLine + newLine);
            
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirArquivo = new OpenFileDialog();
            abrirArquivo.RestoreDirectory = true;
            abrirArquivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            abrirArquivo.DefaultExt = "txt";

            if (abrirArquivo.ShowDialog() == DialogResult.OK)
            {
                //Armazenando o valor da string extraída.
                string strArquivo = File.ReadAllText(abrirArquivo.FileName, Encoding.UTF8);

                //Contador de índices do Textbox.
                int contadorTextBox = 0;

                //Limpando os valores preenchidos nos textboxes primeiro antes de preencher
                //com os valores lidos do txt.
                foreach (TextBox tb in listTextbox) { tb.Clear(); }

                //Preenchendo os textboxes com os valores.
                for (int i = 0; i < strArquivo.Length; i++)
                {
                    if (strArquivo[i] != '\n')
                    {
                        listTextbox[contadorTextBox].Text += strArquivo[i].ToString();

                    } else
                    {
                        contadorTextBox++;  //Quando o caractere na posição de i for igual
                                            //à um pulo de linha, passa para o próximo vetor.
                    }
                }

                consoleSaida.AppendText($"[!] Arquivo carregado de {abrirArquivo.FileName}" + newLine + newLine);
            }
        }

        //Verifica se o valor de classe selecionado é igual a A: se sim, a opção de inserir
        //um valor de uplink é habilitada.
        private void comboBoxClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valorSelecionado = comboBoxClasse.SelectedItem.ToString();

            switch (valorSelecionado)
            {
                case "A":
                    upDownUplink.Enabled = true; 
                break;

                default:
                    upDownUplink.Enabled = false; 
                break;
            }
        }
    }
}