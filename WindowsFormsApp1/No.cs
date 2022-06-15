using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class No
    {
        private String elemento;
        private No next;

        public No(String conteudo, No n)
        {
            elemento = conteudo;
            next = n;
        }
        public String getElemento()
        {
            return elemento;
        }
        public No getNext()
        {
            return next;
        }
        public void setElemento(String e)
        {
            elemento = e;
        }
        public void setNext(No n)
        {
            next = n;
        }

        public override string ToString()
        {
            return "Conteúdo: " + this.elemento;
        }
    }
}
