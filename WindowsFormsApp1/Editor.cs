using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Editor
    {
        private string[] dicio { get; set; }

        public Editor()
        {
            dicio = carregaDicio();
        }
        public string[] carregaDicio()
        {
            string path = @"C:\Users\lucas\OneDrive\Documentos\dicionario.txt";
            string conteudo = File.ReadAllText(path, Encoding.UTF8);

            return conteudo.Split(',');
        }
        public void setDicio(string plvSalvar)
        {
            string path = @"C:\Users\lucas\OneDrive\Documentos\dicionario.txt";
            File.AppendAllText(path, plvSalvar);
            dicio = carregaDicio();
        }

        public string[] comparaTexto(string[] textoLimpo)
        {
            string[] unknownWords = new string[1000000];

            for(int i = 0; i < textoLimpo.Length; i++)
            {
                if (!this.dicio.Contains(textoLimpo[i]))
                {
                    unknownWords[i] = textoLimpo[i];
                }
            }

            return unknownWords;
        }

    }
}
