using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // CORRIGIR A LISTA, VINDO COM ESPAÇO

            // QUANDO O USUÁRIO INSERE O TEXTO
            string text = textBox1.Text;
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
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

            Console.WriteLine(dicionario);


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var abrirArquivo = new OpenFileDialog();
            abrirArquivo.Title = "Selecione um arquivo";
            abrirArquivo.Filter = "txt file|*txt";
            abrirArquivo.RestoreDirectory = true;
        }
    }
}
