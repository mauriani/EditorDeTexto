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
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Editor editor = new Editor();
        public Form1()
        {
            InitializeComponent();
            
        }

        // FUNÇÕES

       

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
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
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
            catch (Exception error)
            {
                MessageBox.Show("Atenção" + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int hash_Insert(string str)
        {
            // função hash
            byte[] ASCIIvalues = Encoding.ASCII.GetBytes(str);
            int result = 0;


            foreach (var value in ASCIIvalues)
            {
                result = value + result;
            }

            return result % 100;

        }
        int[] vetor = new int[100];

        // QUANDO O USUÁRIO INSERE O TEXTO
        private void button1_Click(object sender, EventArgs e)
        {

            //Limpando checkbox antes de prosseguir com a função
            checkedListBox1.Items.Clear();

            string text = richTextBox1.Text;

            // REMOVENDO CARACTERES ESPECIAIS DO INPUT DO USUARIO
            string textoLimpo = text;
            string[] caracteresEspeciais = { "¹", "²", "³", "£", "¢", "¬", "º", "¨", "'", ".", ",", "-", ":", "(", ")", "ª", "|", "\\", "°", "_", "@", "#", "!", "$", "%", "&", "*", ";", "/", "<", ">", "?", "[", "]", "{", "}", "=", "+", "§", "´", "`", "^", "~", "\n", "\"", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            for (int i = 0; i < caracteresEspeciais.Length; i++)
            {
                textoLimpo = textoLimpo.Replace(caracteresEspeciais[i], "");
            }

            string[] arrTextoLimpo = textoLimpo.Split(' ');
            string[] palavrasDesconhecidas = editor.comparaTexto(arrTextoLimpo);

            List<string> plvCkBox = new List<string>();

            foreach (string palavra in palavrasDesconhecidas)
            {
                if(palavra != null)
                {
                    if (!plvCkBox.Contains(palavra))
                    {
                        plvCkBox.Add(palavra);
                    }
                    
                }
            }

            string[] arrPlvCkBox = plvCkBox.ToArray();

            checkedListBox1.Items.AddRange(arrPlvCkBox);
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string plvSalvar = "";

            foreach(string item in checkedListBox1.Items)
            {
                if (checkedListBox1.CheckedItems.Contains(item))
                {
                    plvSalvar = plvSalvar + ',' + item;
                }
            }

            editor.setDicio(plvSalvar);

            button1_Click(null, null);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
