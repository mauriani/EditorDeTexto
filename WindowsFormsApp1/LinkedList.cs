using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class LinkedList:Node
    {

        public LinkedList() {}

        private string head = null;

        public void addElement(string valor)
        {
            // Instanciando a classe
            Node novoNo = new Node();

            novoNo.Valor = valor;

        }

       

       
    }
}
