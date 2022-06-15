using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // FUNÇÕES

        private void salva_arquivo_lista()
        {
            string text = richTextBox1.Text;
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string[] words = text.Split(delimiterChars);
            List<string> dicionario = new List<string>();

            foreach (var word in words)
            {
                System.Console.WriteLine(word);

                if (word.Length > 0)
                {
                    dicionario.Add(word);
                }
            }

            Console.WriteLine(dicionario);
        }

        private void alert_Salvar()
        {
            // BUTTON NOVO ARQUIVO
            // PRIMEIRO VAMOS FAZER UM ALERT
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                if ((MessageBox.Show("Deseja Salvar o arquivo ?", "Salvar ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
                {
                    salvar_Arquivo();
                }
            }
        }

        private void salvar_Arquivo()
        {
            try
            {
                // ABRE A JANELA DO COMPUTADOR PARA ESCOLHER ONDE SALVAR O ARQUIVO
                if(this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // abre um stream para escrita e cria um StreamWriter para implementar o stream
                    FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter m_streamWriter = new StreamWriter(fs);
                    m_streamWriter.Flush();
                    // Escreve para o arquivo usando a classe StreamWriter
                    m_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    // escreve no controle richtextbox
                    m_streamWriter.Write(this.richTextBox1.Text);
                    // fecha o arquivo
                    m_streamWriter.Flush();
                    m_streamWriter.Close();
                }

            }
            catch(Exception error)
            {
                MessageBox.Show("Atenção" + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void hash_Insert()
        {
           // função hash

        }
        int[] vetor = new int[100];

        // QUANDO O USUÁRIO INSERE O TEXTO
        private void button1_Click(object sender, EventArgs e)
        {
            // CORRIGIR A LISTA, VINDO COM ESPAÇO

            
            string text = richTextBox1.Text;
            char[] delimiterChars = { ' ', ',', '.', ':', '\t','\n' };
            string[] words = text.Split(delimiterChars);
            List<string> dicionario = new List<string>();

            foreach (var word in words)
            {
                System.Console.WriteLine(word);

                if(word.Length > 0)
                {
                    dicionario.Add(word);
                } 
            }

            Console.WriteLine(dicionario + "dicionario");


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
          
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // NOVO ARQUIVO
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            alert_Salvar();
            richTextBox1.Focus();
            richTextBox1.Clear();
        }

        // ABRIR ARQUIVO EXISTENTE
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // isso afirmar que o arquivo pode ser multilinhas
            this.openFileDialog.Multiselect = true;

            // selecionar mais de um arquivo e FileNames
            this.openFileDialog.Title = "Selecione o arquivo";

            // Diretório a ser exibido quando a janela de diálogo aparecer pela primeira vez
            openFileDialog.InitialDirectory = @"C:\";

            // FILTRA APENAS ARQUIVOS DE TEXTO
            openFileDialog.Filter = "Images (*.TXT)|*.TXT|" + "All files (*.*)|*.*";

            // Representa o indíce do filtro atualmetne selecionado na janela de diálogo
            openFileDialog.FilterIndex = 1;

            // Indica se a caixa de verificação estará selecionada
            this.openFileDialog.ReadOnlyChecked = true;


            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ShowReadOnly = true;

            DialogResult dr = this.openFileDialog.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader m_streamReader = new StreamReader(fs);
                    // Lê o arquivo usando a classe StreamReader
                    m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    // Lê cada linha do stream e faz o parse até a última linha
                    this.richTextBox1.Text = "";
                    string strLine = m_streamReader.ReadLine();
                    while (strLine != null)
                    {
                        this.richTextBox1.Text += strLine + "\n";
                        strLine = m_streamReader.ReadLine();
                    }
                    // Fecha o stream
                    m_streamReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        
        // BUTTON MENU SALVAR ARQUIVO
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            salvar_Arquivo();

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
