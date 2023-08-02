using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace WinFormsTeste
{
    public partial class Form1 : Form
    {

        //String que sinaliza quebras de linha em textos.
        string newLine = System.Environment.NewLine;

        //Instanciando objeto de acesso às portas COMs.
        SerialPort _serialPort = new SerialPort();

        //Variável que recebe as strings dos três textboxes.
        string strConcat;

        //Recebe o total da soma de todos os limites de caracteres dos três inputs.
        int totalMaxLength;

        public Form1()
        {
            InitializeComponent();

            //Adiciona números possíveis de portas COMs selecionáveis dentro da Combobox.
            for (int i = 1; i <= 50; i++){
                comboBoxCOM.Items.Add("COM" + i);
            }

            comboBoxCOM.SelectedIndex = 0; //Seleciona o primeiro do índice de itens da combobox.

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

                        btConectar.Text = "Desconectar";

                        MessageBox.Show($"Conectado com sucesso na porta {portSelecionado}.");

                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Não foi possível se conectar.\n\n" + erro.Message, "Erro");
                    }

                }

            }
            else if (btConectar.Text == "Desconectar")
            {
                //Desconecta da porta.
                _serialPort.Close();

                //Desabilitando interações com alguns elementos.
                comboBoxCOM.Enabled = true;
                groupBox_Enviar.Enabled = false;
                salvarComoToolStripMenuItem.Enabled = false;

                txt1.Clear();
                txt2.Clear();
                txt3.Clear();

                btConectar.Text = "Conectar";

            }

        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            strConcat = txt1.Text + txt2.Text + txt3.Text;
            totalMaxLength = txt1.MaxLength + txt2.MaxLength + txt3.MaxLength;

            if (strConcat.Length == totalMaxLength)
            {
                _serialPort.Write(strConcat);   //Escreve os valores na porta especificada.

                consoleSaida.AppendText("Enviado: " + strConcat + newLine); //Exibe os valores de entrada.


            } else
            {
                MessageBox.Show("A informação enviada é inválida.", "Erro");

                consoleSaida.AppendText("Erro: a informação enviada é inválida." + newLine); //Exibe os valores de entrada.

            }
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            totalMaxLength = txt1.MaxLength + txt2.MaxLength + txt3.MaxLength;

            if (txt1.Text.Length + txt2.Text.Length + txt3.Text.Length == totalMaxLength)
            {
                SaveFileDialog salvaArquivo = new SaveFileDialog();
                salvaArquivo.FileName = "*.txt";
                salvaArquivo.RestoreDirectory = true;
                salvaArquivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                salvaArquivo.DefaultExt = "txt";

                OpenFileDialog abrirArquivo = new OpenFileDialog();

                if (salvaArquivo.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(salvaArquivo.FileName, $"Valores salvos:\n\n" +
                                                             $"Valor 1: {txt1.Text}\n" +
                                                             $"Valor 2: {txt2.Text}\n" +
                                                             $"Valor 3: {txt3.Text}");
                }

            } else
            {
                MessageBox.Show("Não foi possível salvar: os valores dos campos não somam 48 caracteres. Tente novamente.", "Erro");
            
            }
        }
    }
}