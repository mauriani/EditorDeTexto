using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    public class ListaEncadeada
    {
        private No cabeca;
        private int qtdElementos;

        public ListaEncadeada()
        {
            cabeca = new No(null, null);
            qtdElementos = 0;
        }

        public void Inseri(int i, No n)
        {
            if (i > qtdElementos)
            {
                No noAux = this.cabeca;

                for (int j = 0; j < qtdElementos; j++)
                {
                    noAux = noAux.getNext();
                }

                noAux.setNext(n);
                n.setNext(null);

                qtdElementos++;
            }
            else
            {
                No noAux = this.cabeca;

                for (int j = 0; j < i - 1; j++)
                {
                    noAux = noAux.getNext();
                }

                No noAfter = noAux.getNext();

                noAux.setNext(n);
                n.setNext(noAfter);

                qtdElementos++;
            }
        }
        public No Busca(int i)
        {
            No aux;

            if (i > this.qtdElementos)
            {
                return null;
            }
            else
            {
                aux = this.cabeca;

                for (int k = i; k > 0; k--)
                {
                    aux = aux.getNext();
                }

                return aux;
            }
        }
    }
}